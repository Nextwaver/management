using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebManagement.Models;
using Microsoft.AspNetCore.Builder;
using System.IO;
using System.Net;
using System.Data;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace WebManagement.Controllers
{
    public class AccountController : Controller
    {
        string APIService = "https://localhost:5001/WS/V1/";
        private ServiceController sv;
        public AccountController(IConfiguration configuration)
        {            
            Configuration = configuration;
            //var ApiUrl = Environment.GetEnvironmentVariable("serverUrl");
            //APIService = "https://localhost:5001/WS/V1/";
            sv = new ServiceController(configuration);
        }
        public IConfiguration Configuration { get; }
 
        String Connection = "NextwaverDatabase";
        String OfficeSpaceId = "OF.0001";
        String DatabaseName = "Doc";
        String TableName = "Users";
        static SignInErrorMsg errMsg = new SignInErrorMsg();
        NextwaverDB.NColumns NCS = new NextwaverDB.NColumns();
        NextwaverDB.NWheres NWS = new NextwaverDB.NWheres();
        JObject json;
        private ErrorMessageModel ms = new ErrorMessageModel();

        #region SignIn authentication
        public IActionResult Login()
        {

            ViewBag.name = errMsg.MessageError;

            if (User.Identity.Name == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("SelectUser", "Account");
            }
        }

        [HttpPost]
        public IActionResult SignIn()
        {
            LoginModel user = new LoginModel();
            user.Username = Request.Form["TxbUsername"];
            user.Password = Request.Form["TxbPassword"];

            // String currentUser = "Admin", currentPassword = "nextwaver";
            NextwaverDB.NWheres NWS = new NextwaverDB.NWheres();

            NWS.Add(new NextwaverDB.NWhere("USERNAME", user.Username));
            NWS.Add(new NextwaverDB.NWhere("PASSWORD", user.Password));
            NWS.Add(new NextwaverDB.NWhere("STATUS", ""));

            NextwaverDB.NColumns NCS_S = new NextwaverDB.NColumns();
            NCS_S.Add(new NextwaverDB.NColumn("USERNAME"));
            NCS_S.Add(new NextwaverDB.NColumn("POSITION_CODE"));
            NCS_S.Add(new NextwaverDB.NColumn("ID"));

            String NCS_Encrypt = sv.Encrypt(NCS_S.ExportString());
            String NWS_Encrypt = sv.Encrypt(NWS.ExportString());

            String url = APIService + "SelectByColumnAndWhere?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=" + TableName + "&NColumns_encrypt=" + NCS_Encrypt + "&NWheres_encrypt=" + NWS_Encrypt + "&User=system";
            DataTable dt = sv.ConvertJsonToDatatableLinq(sv.CallAPI(url, "GET"));
            if (dt.Rows.Count == 0)
            {
                errMsg.MessageError = "UserName หรือ Password ไม่ถูกต้อง";
            }
            else if (dt.Rows.Count == 1)
            {
                SetUserName(dt);
                return RedirectToAction("Index", "Home");
            }
            else if (dt.Rows.Count > 1 && dt.Rows[0][0].ToString() == "Error")
            {
                errMsg.MessageError = dt.Rows[1][0].ToString();
            }
            return RedirectToAction("Login", "Account"); ;
        }
        public IActionResult LoginFacebook(String provider)
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "/Account/SelectUser"});
        }
 
        public async Task SignOutFacebook()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task<IActionResult> SignOut()
        {
            HttpContext.Session.Remove("ID");
            HttpContext.Session.Remove("USERNAME");
            HttpContext.Session.Remove("POSITION_CODE");
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        public async Task<IActionResult> SelectUser()
        {
            Boolean status = true;
            String MsgError = "";
            String AuthenType = User.Identity.AuthenticationType;

            if (AuthenType.ToUpper() == "FACEBOOK")
                AuthenType = "FB";

            String UserID = GetUserIDFacebook();
            DataTable dtTemp = SelectUserFromWS(UserID);

            if (status && dtTemp.Rows.Count == 0)
            {
                JObject json = InsertUser(UserID, AuthenType);

                if (json["dataList"][0]["data"].ToString().ToUpper() != "OK")
                {
                    status = false;
                    MsgError = json["dataList"][1]["data"].ToString();
                }
                else
                    dtTemp = SelectUserFromWS(UserID);
            }
            if (dtTemp.Rows.Count > 1 && dtTemp.Rows[0][0].ToString() == "Error")
            {
                status = false;
                MsgError = dtTemp.Rows[1][0].ToString();
            }

            if (status)
            {
                SetUserName(dtTemp);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                await SignOutFacebook();
                errMsg.MessageError = MsgError;

                return RedirectToAction("Login", "Account");
            }
        }
 
        private DataTable SelectUserFromWS(string userID)
        {
            DataTable table = new DataTable();
            NextwaverDB.NWheres NWS = new NextwaverDB.NWheres();

            NWS.whereType = true;
            NWS.Where = "";
            NWS.Where += "[@USERNAME@ = '" + userID + "']";
            string NWS_Encrypt = sv.Encrypt(NWS.ExportString());
            String url = APIService + "SelectAllColumnByWhere?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=" + TableName + "&NWheres_String=" + NWS.ExportString() + "&User=system";
            table = sv.ConvertJsonToDatatableLinq(sv.CallAPI(url, "GET"));

            return table;
        }

        private string GetUserIDFacebook()
        {
            var UserList = ((System.Security.Claims.ClaimsIdentity)User.Identity).Claims;
            String UserID = "";
 
            foreach (var item in UserList)
            {
                if (item.Type.Contains("/nameidentifier"))
                {
                    UserID = item.Value.ToString();
                }
            }
            return UserID;
        }

        private JObject InsertUser(String userID, String AuthenType)
        {
            NextwaverDB.NColumns NCS = new NextwaverDB.NColumns();

            NCS.Add(new NextwaverDB.NColumn("SPACE_USER", AuthenType));
            NCS.Add(new NextwaverDB.NColumn("POSITION_CODE", "002"));
            NCS.Add(new NextwaverDB.NColumn("USERNAME", userID));
            NCS.Add(new NextwaverDB.NColumn("CREATE_DATE", DateTime.Now.ToString("dd/MM/yyyy")));
            NCS.Add(new NextwaverDB.NColumn("CREATE_BY", "system"));

            string NCS_Encrypt = sv.Encrypt(NCS.ExportString());

            String Insert = APIService + "InsertData?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=" + TableName + "&NColumns_String=" + NCS.ExportString() + "&strDOC=&User=system";

            JObject json = sv.ConvertJsonStringToJObject(sv.CallAPI(Insert, "POST"));
            return json;
        }

        private void SetUserName(DataTable dt)
        {
            HttpContext.Session.SetString(Account.NameType.ID.ToString(), dt.Rows[0]["ID"].ToString());
            HttpContext.Session.SetString(Account.NameType.Username.ToString(), dt.Rows[0]["USERNAME"].ToString());
            HttpContext.Session.SetString(Account.NameType.Position.ToString(), dt.Rows[0]["POSITION_CODE"].ToString());
        }
        #endregion

        #region Manage Data User
        [HttpPost]
        public JsonResult SaveUser(Account acm)
        {
            ms = new ErrorMessageModel();
            String Action = "New";
            if (acm.ID != null) Action = "Edit";

            NWS = new NextwaverDB.NWheres();
            NWS.whereType = true;
            NWS.Where = "[@USERNAME@ = '" + acm.Username + "']";
            if (Action != "New") NWS.Where += "[@ID@ != '" + acm.ID + "']";

            NCS = new NextwaverDB.NColumns();
            NCS.Add(new NextwaverDB.NColumn("USERNAME"));

            String NCS_Encrypt = sv.Encrypt(NCS.ExportString());
            String NWS_Encrypt = sv.Encrypt(NWS.ExportString());

            String url =  APIService + "SelectByColumnAndWhere?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=" + TableName + "&NColumns_encrypt=" + NCS_Encrypt + "&NWheres_encrypt=" + NWS_Encrypt + "&User=system";
            DataTable dt = sv.ConvertJsonToDatatableLinq(sv.CallAPI(url, "GET"));

            if (dt.Rows.Count > 0)
            {
                acm._ErrorMessageModel.Code = "Error";
                acm._ErrorMessageModel.Message = "ชื่อผู้ใช้งานนี้มีอยู่แล้วในระบบโปรดระบุใหม่";
                return Json(acm);
            }
            NCS = new NextwaverDB.NColumns();
            if (acm.SpaceUser != "WS" && acm.SpaceUser != null)
                NCS.Add(new NextwaverDB.NColumn("SPACE_USER", acm.SpaceUser));
            else
                NCS.Add(new NextwaverDB.NColumn("SPACE_USER", "WS"));

            NCS.Add(new NextwaverDB.NColumn("TITLE", acm.Titile));
            NCS.Add(new NextwaverDB.NColumn("FIRSTNAME", acm.FirstName));
            NCS.Add(new NextwaverDB.NColumn("LASTNAME", acm.LastName));
            NCS.Add(new NextwaverDB.NColumn("POSITION_CODE", acm.Position));
            NCS.Add(new NextwaverDB.NColumn("PASSWORD", acm.Password));
            if (Action == "New")
            {
                NCS.Add(new NextwaverDB.NColumn("USERNAME", acm.Username));   
                NCS.Add(new NextwaverDB.NColumn("CREATE_DATE", DateTime.Now.ToString("dd/MM/yyyy")));
                NCS.Add(new NextwaverDB.NColumn("CREATE_BY", "system"));

                url =  APIService + "InsertData?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=" + TableName + "&NColumns_String=" + NCS.ExportString() + "&strDOC=&User=system";
            }
            else
            {
                NCS.Add(new NextwaverDB.NColumn("UPDATE_DATE", DateTime.Now.ToString("dd/MM/yyyy")));
                NCS.Add(new NextwaverDB.NColumn("UPDATE_BY", "system"));
                NWS = new NextwaverDB.NWheres();
                NWS.Add("ID", acm.ID);

                url =  APIService + "UpdateData?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=" + TableName + "&NColumns_String=" + NCS.ExportString() + "&NWheres_String=" + NWS.ExportString() + "&strDOC=&User=system";
            }

            json = new JObject(sv.ConvertJsonStringToJObject(sv.CallAPI(url, "POST")));
            acm._ErrorMessageModel.Code = json["dataList"][0]["data"].ToString();
            acm._ErrorMessageModel.Message = json["dataList"][1]["data"].ToString();
            return Json(acm);
        }

        [HttpGet]
        public JsonResult LoadDataUser(String ID)
        {
            Account acm = new Account();
            ms = new ErrorMessageModel();
            NWS = new NextwaverDB.NWheres();
            NWS.whereType = true;
            NWS.Where += "[@ID@ = '" + ID + "']";

            // string NWS_Encrypt = new EncryptDecrypt.CryptorEngine().Encrypt(NWS.ExportString(), true);
            string NWS_Encrypt = sv.Encrypt(NWS.ExportString());
            try
            {
                String url =  APIService + "SelectAllColumnByWhere?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=" + TableName + "&NWheres_String=" + NWS.ExportString() + "&User=system";
                DataTable dt = sv.ConvertJsonToDatatableLinq(sv.CallAPI(url, "GET"));

                acm.Titile = "" + dt.Rows[0]["TITLE"];
                acm.FirstName = "" + dt.Rows[0]["FIRSTNAME"];
                acm.LastName = "" + dt.Rows[0]["LASTNAME"];
                acm.Position = "" + dt.Rows[0]["POSITION_CODE"];
                acm.Username = "" + dt.Rows[0]["USERNAME"];
                acm.Password = "" + dt.Rows[0]["PASSWORD"];
                acm._ErrorMessageModel.Code = "OK";
                return Json(acm);
            }
            catch (Exception ex)
            {
                acm._ErrorMessageModel.Code = "Error";
                acm._ErrorMessageModel.Message = ex.Message;
                return Json(ms);
            }
        }
        #endregion

        #region Manage Data Position
        [HttpPost]
        public JsonResult SavePosition(PositionManage pm)
        {
            ms = new ErrorMessageModel();
            String Action = "New";
            if (pm.ID != null) Action = "Edit";

            NWS = new NextwaverDB.NWheres();
            NWS.whereType = true;
            NWS.Where = "[@POSITION_NAME@ = '" + pm.PositionName + "']";
            if (Action != "New") NWS.Where += "[@ID@ != '" + pm.ID + "']";

            NCS = new NextwaverDB.NColumns();
            NCS.Add(new NextwaverDB.NColumn("POSITION_NAME"));

            //  String NCS_Encrypt = new EncryptDecrypt.CryptorEngine().Encrypt(NCS_S.ExportString(), true);
            //  String NWS_Encrypt = new EncryptDecrypt.CryptorEngine().Encrypt(NWS.ExportString(), true);
            String NCS_Encrypt = sv.Encrypt(NCS.ExportString());
            String NWS_Encrypt = sv.Encrypt(NWS.ExportString());

            String url = APIService + "SelectByColumnAndWhere?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=Position&NColumns_encrypt=" + NCS_Encrypt + "&NWheres_encrypt=" + NWS_Encrypt + "&User=system";
            DataTable dt = sv.ConvertJsonToDatatableLinq(sv.CallAPI(url, "GET"));

            if (dt.Rows.Count > 0)
            {
                pm._ErrorMessageModel.Code = "Error";
                pm._ErrorMessageModel.Message = "ชื่อตำแหน่งนี้มีอยู่แล้วในระบบโปรดระบุใหม่";
                return Json(pm);
            }

            if (Action == "New")
            {
                NCS = new NextwaverDB.NColumns();
                NCS.Add(new NextwaverDB.NColumn("POSITION_CODE", getNewPOSITION_CODE()));
                NCS.Add(new NextwaverDB.NColumn("POSITION_NAME", pm.PositionName));
                NCS.Add(new NextwaverDB.NColumn("MENU", pm.MenuActive));
                NCS.Add(new NextwaverDB.NColumn("CREATE_DATE", DateTime.Now.ToString("dd/MM/yyyy")));
                NCS.Add(new NextwaverDB.NColumn("CREATE_BY", "system"));

                url = APIService + "InsertData?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=Position&NColumns_String=" + NCS.ExportString() + "&strDOC=&User=system";

                JObject json = sv.ConvertJsonStringToJObject(sv.CallAPI(url, "POST"));

                pm._ErrorMessageModel.Code = json["dataList"][0]["data"].ToString();
                pm._ErrorMessageModel.Message = json["dataList"][1]["data"].ToString();
                return Json(pm);
            }
            else
            {
                NCS = new NextwaverDB.NColumns();
                NCS.Add(new NextwaverDB.NColumn("POSITION_NAME", pm.PositionName));
                NCS.Add(new NextwaverDB.NColumn("MENU", pm.MenuActive));
                NCS.Add(new NextwaverDB.NColumn("UPDATE_DATE", DateTime.Now.ToString("dd/MM/yyyy")));
                NCS.Add(new NextwaverDB.NColumn("UPDATE_BY", "system"));

                NWS = new NextwaverDB.NWheres();
                NWS.Add("ID", pm.ID);

                url = APIService + "UpdateData?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=Position&NColumns_String=" + NCS.ExportString() + "&NWheres_String=" + NWS.ExportString() + "&strDOC=&User=system";

                JObject json = sv.ConvertJsonStringToJObject(sv.CallAPI(url, "POST"));

                pm._ErrorMessageModel.Code = json["dataList"][0]["data"].ToString();
                pm._ErrorMessageModel.Message = json["dataList"][1]["data"].ToString();
                return Json(pm);
            }
        }
        string getNewPOSITION_CODE()
        {
            NextwaverDB.NXPath NXP = new NextwaverDB.NXPath();
            NextwaverDB.NWheres NWS = new NextwaverDB.NWheres();
            NWS.whereType = true;
            NWS.Where = "[" + NXP.getMaxValue("@POSITION_CODE@") + "]";
 
            NextwaverDB.NColumns NCS_S = new NextwaverDB.NColumns();
            NCS_S.Add(new NextwaverDB.NColumn("POSITION_CODE"));

            String NCS_Encrypt = sv.Encrypt(NCS_S.ExportString());
            String NWS_Encrypt = sv.Encrypt(NWS.ExportString());
 
            String url = APIService + "SelectByColumnAndWhere?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=Position&NColumns_encrypt=" + NCS_Encrypt + "&NWheres_encrypt=" + NWS_Encrypt + "&User=system";
            DataTable dt = sv.ConvertJsonToDatatableLinq(sv.CallAPI(url, "GET"));

            int MaxID = 001;
            string NewID = "";
            if (dt.Rows.Count != 0)
            {
                MaxID =  int.Parse(dt.Rows[0][0].ToString());

                NewID = "" + (MaxID + 1);
                for (int i = NewID.Length; i < 3; i++)
                {
                    NewID = "0" + NewID;
                }
            }
            else
            {
                NewID = Convert.ToString(MaxID);
            }
 
            return NewID;
        }

        [HttpGet]
        public JsonResult LoadDataMenuActive(String ID)
        {
            PositionManage pm = new PositionManage();
            ms = new ErrorMessageModel();
            NWS = new NextwaverDB.NWheres();
            NWS.whereType = true;
            NWS.Where += "[@ID@ = '" + ID + "']";
 
            string NWS_Encrypt = sv.Encrypt(NWS.ExportString());
            try
            {
                String url = APIService + "SelectAllColumnByWhere?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=Position&NWheres_String=" + NWS.ExportString() + "&User=system";
                DataTable dt = sv.ConvertJsonToDatatableLinq(sv.CallAPI(url, "GET"));

               pm.PositionCode = "" + dt.Rows[0]["POSITION_CODE"];
               pm.PositionName = "" + dt.Rows[0]["POSITION_NAME"];
               pm.MenuActive = "" + dt.Rows[0]["MENU"];

                pm._ErrorMessageModel.Code = "OK";
                return Json(pm);
            }
            catch (Exception ex)
            {
                pm._ErrorMessageModel.Code = "Error";
                pm._ErrorMessageModel.Message = ex.Message;
                return Json(ms);
            }
        }
 
        [HttpGet]
        public JsonResult LoadDataPosition(String ID)
        {
            PositionList pl = new PositionList();
            Position pt = new Position();

            String tmpPARENT_CODE = "", url = "";
            if (ID != "")
            {
                NextwaverDB.NWheres NWS = new NextwaverDB.NWheres();
                NWS.whereType = true;
                NWS.Where += "[@ID@ = '" + ID + "']";

                String NWS_Encrypt = sv.Encrypt(NWS.ExportString());
                try
                {
                    url = APIService + "SelectAllColumnByWhere?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=Position&NWheres_String=" + NWS.ExportString() + "&User=system";
                    DataTable tmp_dt = sv.ConvertJsonToDatatableLinq(sv.CallAPI(url, "GET"));
                    tmpPARENT_CODE = "" + tmp_dt.Rows[0]["PARENT_CODE"];
                }
                catch (Exception ex)
                {
                    pl._ErrorMessageModel.Code = "Error";
                    pl._ErrorMessageModel.Message = ex.Message;
                    return Json(pl);
                }

                url = APIService + "SelectAll?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=position&User=system";
                DataTable dt = sv.ConvertJsonToDatatableLinq(sv.CallAPI(url, "GET"));


                String strSort = "POSITION_CODE ASC";
                DataView dtview = new DataView(dt);
                dtview.Sort = strSort;
                DataTable dtsorted = dtview.ToTable();

                String POSITION_NAME, POSITION_CODE;
                for (int i = 0; i < dtsorted.Rows.Count; i++)
                {
                    if (dtsorted.Rows[i]["STATUS"].ToString() == "")
                    {
                        POSITION_NAME = dtsorted.Rows[i]["POSITION_NAME"].ToString();
                        POSITION_CODE = dtsorted.Rows[i]["POSITION_CODE"].ToString();


                        pt = new Position();
                        pt.Code = POSITION_CODE = dtsorted.Rows[i]["POSITION_CODE"].ToString();
                        pt.Name = dtsorted.Rows[i]["POSITION_NAME"].ToString();

                        if (tmpPARENT_CODE.Trim() == POSITION_CODE.Trim())
                            pt.Check = "1";
                        else
                            pt.Check = "0";
                    }
                }
                pl.Position.Add(pt);
                pl._ErrorMessageModel.Code = "OK";
            }
            return Json(pt);
        }

        #endregion

    }
}