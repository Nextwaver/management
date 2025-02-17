using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using WebManagement.Models;

namespace WebManagement.Controllers
{
    public class GunRegistrationController : Controller
    {

        String Connection = "NextwaverDatabase";
        String OfficeSpaceId = "OF.0001";
        String DatabaseName = "Doc";
        String TableName = "Book";
        static SignInErrorMsg errMsg = new SignInErrorMsg();
        NextwaverDB.NColumns NCS = new NextwaverDB.NColumns();
        NextwaverDB.NWheres NWS = new NextwaverDB.NWheres();
        String _username;

        private ErrorMessageModel ms = new ErrorMessageModel();
        private ServiceController sv;

        XmlDocument xDoc = new XmlDocument();
        private String contentRootPath;
        JObject json;

        string RootPathPage = "//Document/Data/Section[@ID='1']/Items[@Name='Page']";

        public GunRegistrationController(IHostingEnvironment hostingEnvironment, IConfiguration configuration, IHttpContextAccessor ihttpContextAccessor)
        {
            Configuration = configuration;
            var ApiUrl = Environment.GetEnvironmentVariable("serverUrl");
            Configuration["APIService:url"] = ApiUrl;
            contentRootPath = hostingEnvironment.ContentRootPath;
            IHttpCtAcs = ihttpContextAccessor;
            _username = IHttpCtAcs.HttpContext.Session.GetString("Username");
            sv = new ServiceController(configuration);
        }
        public IConfiguration Configuration { get; }
        public IHttpContextAccessor IHttpCtAcs { get; }
        #region Manage Data GunRegistration

        [HttpPost]
        public JsonResult SaveBook(Book bk)
        {
            ms = new ErrorMessageModel();
            String Action = "New";
            if (bk.ID != null) Action = "Edit";

            NWS = new NextwaverDB.NWheres();
            NWS.whereType = true;
            NWS.Where = "[@BOOKNO@ = '" + bk.BookNo + "']";
            if (Action != "New") NWS.Where += "[@ID@ != '" + bk.ID + "']";

            NCS = new NextwaverDB.NColumns();
            NCS.Add(new NextwaverDB.NColumn("BOOKNO"));

            String NCS_Encrypt = sv.Encrypt(NCS.ExportString());
            String NWS_Encrypt = sv.Encrypt(NWS.ExportString());

            String url = Configuration["APIService:url"] + "SelectByColumnAndWhere?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=" + TableName + "&NColumns_encrypt=" + NCS_Encrypt + "&NWheres_encrypt=" + NWS_Encrypt + "&User=system";
            DataTable dt = sv.ConvertJsonToDatatableLinq(sv.CallAPI(url, "GET"));

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count == 2)
                {
                    bk._ErrorMessageModel.Code = json["dataList"][0]["data"].ToString();
                    bk._ErrorMessageModel.Message = json["dataList"][1]["data"].ToString();
                    return Json(bk);
                }
                else
                {
                    bk._ErrorMessageModel.Code = "Error";
                    bk._ErrorMessageModel.Message = "เลขที่หนังสือนี้มีอยู่แล้วในระบบโปรดระบุใหม่";
                    return Json(bk);
                }
            }

            xDoc = new XmlDocument();
            if (bk.ID == null)
                xDoc.Load(System.IO.Path.Combine(contentRootPath, "ManagementConfig/tempdoc/Book.xml"));
            else
            {
                url = Configuration["APIService:url"] + "SelectLastDocument?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=" + TableName + "&ItemId=" + bk.ID + "&User=system";

                json = new JObject(sv.ConvertJsonStringToJObject(sv.CallAPI(url, "GET")));
                xDoc.LoadXml(json["dataList"][2]["data"].ToString());
            }

            //=======INSERT DATA IN STICKER=========
            NCS = new NextwaverDB.NColumns();
            NCS.Add(new NextwaverDB.NColumn("BOOKNO", bk.BookNo));
            NCS.Add(new NextwaverDB.NColumn("BOOKYEAR", bk.BookYear));
            NCS.Add(new NextwaverDB.NColumn("GROUPGUN", bk.GroupGun));
            NCS.Add(new NextwaverDB.NColumn("GUNREGIDPREFIX", bk.GunRegIDPrefix));
            NCS.Add(new NextwaverDB.NColumn("GUNREGIDSTART", bk.GunRegIDStart));
            NCS.Add(new NextwaverDB.NColumn("GUNREGIDEND", bk.GunRegIDEnd));
            NCS.Add(new NextwaverDB.NColumn("PAGETOTAL", bk.PageTotal));

            string RootPath = "//Document/Data/Section[@ID='1']/Items[@Name='GunBook']";
            //=======INSERT DATA IN DOCUMNET=========
            sv.AddDataXmlNode(xDoc, RootPath + "/Item[@Name='BookNo']", bk.BookNo);
            sv.AddDataXmlNode(xDoc, RootPath + "/Item[@Name='BookYear']", bk.BookYear);
            sv.AddDataXmlNode(xDoc, RootPath + "/Item[@Name='GunRegIDPrefix']", bk.GunRegIDPrefix);
            sv.AddDataXmlNode(xDoc, RootPath + "/Item[@Name='GunRegIDStart']", bk.GunRegIDStart);
            sv.AddDataXmlNode(xDoc, RootPath + "/Item[@Name='GunRegIDEnd']", bk.GunRegIDEnd);
            sv.AddDataXmlNode(xDoc, RootPath + "/Item[@Name='PageTotal']", bk.PageTotal);

            if (Action == "New")
            {
                NCS.Add(new NextwaverDB.NColumn("CREATE_DATE", DateTime.Now.ToString("dd/MM/yyyy")));
                NCS.Add(new NextwaverDB.NColumn("CREATE_BY", _username));
                sv.AddDataXmlNode(xDoc, RootPath + "/Item[@Name='CreateDate']", DateTime.Now.ToString("dd/MM/yyyy"));
                sv.AddDataXmlNode(xDoc, RootPath + "/Item[@Name='CreateBy']", _username);
                string strDoc = xDoc.OuterXml;
                url = Configuration["APIService:url"] + "InsertData?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=" + TableName + "&NColumns_String=" + NCS.ExportString() + "&strDOC=" + strDoc + "&User=" + _username;
            }
            else
            {
                NCS.Add(new NextwaverDB.NColumn("UPDATE_DATE", DateTime.Now.ToString("dd/MM/yyyy")));
                NCS.Add(new NextwaverDB.NColumn("UPDATE_BY", _username));
                sv.AddDataXmlNode(xDoc, RootPath + "/Item[@Name='UpdateDate']", DateTime.Now.ToString("dd/MM/yyyy"));
                sv.AddDataXmlNode(xDoc, RootPath + "/Item[@Name='UpdateBy']", _username);
                NWS = new NextwaverDB.NWheres();
                NWS.Add("ID", bk.ID);

                string strDoc = xDoc.OuterXml;

                url = Configuration["APIService:url"] + "UpdateData?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=" + TableName + "&NColumns_String=" + NCS.ExportString() + "&NWheres_String=" + NWS.ExportString() + "&strDOC=" + strDoc + "&User=system";
            }

            json = new JObject(sv.ConvertJsonStringToJObject(sv.CallAPI(url, "POST")));
            bk._ErrorMessageModel.Code = json["dataList"][0]["data"].ToString();
            bk._ErrorMessageModel.Message = json["dataList"][1]["data"].ToString();

            if (bk._ErrorMessageModel.Code.ToUpper() == "OK")
            {
                NWS = new NextwaverDB.NWheres();
                NWS.Add(new NextwaverDB.NWhere("BOOKNO", bk.BookNo));
                NWS.Add(new NextwaverDB.NWhere("PAGEVERSION", "1"));

                NCS = new NextwaverDB.NColumns();
                NCS.Add(new NextwaverDB.NColumn("BOOKNO"));
                NCS.Add(new NextwaverDB.NColumn("PAGENO"));

                NCS_Encrypt = sv.Encrypt(NCS.ExportString());
                NWS_Encrypt = sv.Encrypt(NWS.ExportString());

                url = Configuration["APIService:url"] + "SelectByColumnAndWhere?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=Page&NColumns_encrypt=" + NCS_Encrypt + "&NWheres_encrypt=" + NWS_Encrypt + "&User="+_username;
                 dt = sv.ConvertJsonToDatatableLinq(sv.CallAPI(url, "GET"));
 
                int MaxPageTotal = dt.Rows.Count;
                if (MaxPageTotal < int.Parse(bk.PageTotal))
                {
                    for (int i = (MaxPageTotal + 1); i <= int.Parse(bk.PageTotal); i++)
                    {
                        NextwaverDB.NColumns NCSPage = new NextwaverDB.NColumns();
                        NCSPage.Add(new NextwaverDB.NColumn("BOOKNO", bk.PageTotal));
                        NCSPage.Add(new NextwaverDB.NColumn("PAGENO", i.ToString()));
                //        NCSPage.Add(new NextwaverDB.NColumn("PAGEVERSION", "1"));
                //        NCSPage.Add(new NextwaverDB.NColumn("PAGESTATUS", "Create"));
                //        NCSPage.Add(new NextwaverDB.NColumn("CREATEDATE", DateTime.Now.ToString("dd/MM/yyyy")));
                //        NCSPage.Add(new NextwaverDB.NColumn("CREATEBY", _username));

                        XmlDocument xDocPage = new XmlDocument();
                        xDocPage.Load(System.IO.Path.Combine(contentRootPath, "ManagementConfig/tempdoc/Page.xml"));

                        sv.AddDataXmlNode(xDocPage, RootPathPage + "/Item[@Name='BookNo']", bk.PageTotal);
                        sv.AddDataXmlNode(xDocPage, RootPathPage + "/Item[@Name='PageNo']", i.ToString());
                   //    sv.AddDataXmlNode(xDocPage, RootPathPage + "/Item[@Name='PageVersion']", "1");
                   //    sv.AddDataXmlNode(xDocPage, RootPathPage + "/Item[@Name='PageStatus']", "Create");
                   //    sv.AddDataXmlNode(xDocPage, RootPathPage + "/Item[@Name='CreateDate']", DateTime.Now.ToString("dd/MM/yyyy"));
                   //    sv.AddDataXmlNode(xDocPage, RootPathPage + "/Item[@Name='CreateBy']", _username);

                        string strDocPage = xDocPage.OuterXml;
 
                        url = Configuration["APIService:url"] + "InsertData?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=Page&NColumns_String=" + NCSPage.ExportString() + "&strDOC=" + strDocPage + "&User=" + _username;
                        json = new JObject(sv.ConvertJsonStringToJObject(sv.CallAPI(url, "POST")));
                        bk._ErrorMessageModel.Code = json["dataList"][0]["data"].ToString();
                        bk._ErrorMessageModel.Message = json["dataList"][1]["data"].ToString();
                    }
                }
            }
            return Json(bk);
        }

        [HttpGet]
        public JsonResult LoadDataBook(String ID)
        {
            Book bk = new Book();
            ms = new ErrorMessageModel();
            NWS = new NextwaverDB.NWheres();
            NWS.whereType = true;
            NWS.Where += "[@ID@ = '" + ID + "']";

            // string NWS_Encrypt = new EncryptDecrypt.CryptorEngine().Encrypt(NWS.ExportString(), true);
            string NWS_Encrypt = sv.Encrypt(NWS.ExportString());
            try
            {
                String url = Configuration["APIService:url"] + "SelectAllColumnByWhere?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=" + TableName + "&NWheres_String=" + NWS.ExportString() + "&User=system";
                DataTable dt = sv.ConvertJsonToDatatableLinq(sv.CallAPI(url, "GET"));

                bk.BookNo = "" + dt.Rows[0]["BOOKNO"];
                bk.BookYear = "" + dt.Rows[0]["BOOKYEAR"];
                bk.GroupGun = "" + dt.Rows[0]["GROUPGUN"];
                bk.GunRegIDPrefix = "" + dt.Rows[0]["GUNREGIDPREFIX"];
                bk.GunRegIDStart = "" + dt.Rows[0]["GUNREGIDSTART"];
                bk.GunRegIDEnd = "" + dt.Rows[0]["GUNREGIDEND"];
                bk.PageTotal = "" + dt.Rows[0]["PAGETOTAL"];
                bk._ErrorMessageModel.Code = "OK";
                return Json(bk);
            }
            catch (Exception ex)
            {
                bk._ErrorMessageModel.Code = "Error";
                bk._ErrorMessageModel.Message = ex.Message;
                return Json(ms);
            }
        }
        #endregion
    }
}