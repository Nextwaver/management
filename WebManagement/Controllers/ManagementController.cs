using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebManagement.Models;

namespace WebManagement.Controllers
{
    public class ManagementController : Controller
    {
        static String OfficeSpaceId = "OF.0001";
        static String Connection = "NextwaverDatabase";
        static String DatabaseName = "Doc";
        private String contentRootPath;
        private readonly IHostingEnvironment _hostingEnvironment;
        private ServiceController sv;

        private XmlDocument xDoc = new XmlDocument();
        private NextwaverDB.NWheres NWS = new NextwaverDB.NWheres();
        private NextwaverDB.NColumns NCS_S = new NextwaverDB.NColumns();
        private ManagementConfig MC = new ManagementConfig();
        private ManagementListConfig MLC = new ManagementListConfig();
        private Records rcs = new Records();
        private Column cl = new Column();
        private Columns cls = new Columns();
        private Tools tls = new Tools();
        private Search srch = new Search();
        private Group grp = new Group();
        public IConfiguration Configuration { get; }
        public IHttpContextAccessor IHttpCtAcs { get; }
        public ManagementController(IHostingEnvironment hostingEnvironment, IConfiguration configuration, IHttpContextAccessor ihttpContextAccessor)
        {
            IHttpCtAcs = ihttpContextAccessor;
            Configuration = configuration;
            var ApiUrl = Environment.GetEnvironmentVariable("serverUrl");
            Configuration["APIService:url"] = ApiUrl;
            sv = new ServiceController(configuration);
            _hostingEnvironment = hostingEnvironment;
            contentRootPath = _hostingEnvironment.ContentRootPath;
            sv.ControllerContext = ControllerContext;
        }
 
        public IActionResult Management(String CFN, String MID, String TID, Boolean IsSearch)
        {
            //management.aspx?ID=0-0-0 && CFN=Administrator && MID=Management1 && TID=Tools1
            Searching SC = new Searching();
            if (WebManagement.Models._Searching.Searching != null) SC = WebManagement.Models._Searching.Searching;
            if (IsSearch) SC.IsSearch = true;
            else SC.IsSearch = false;

            LoadManagement(CFN, MID, TID, SC);
            return View();
        }
        public JsonResult SearchManagement(Searching sc)
        {
            Searching ScTemp = new Searching();
            string MID = sc.MID;

            //  if (MID == null || MID == "" || MID == "null") MID = "";
            //if (TID == "") TID = "Tools1";

            NextwaverDB.NWheres NWS = new NextwaverDB.NWheres();
            NWS.whereType = true;
            NWS.Where = "";

            String SC01 = sc.SC01;
            String ST01 = sc.ST01;
            String SC02 = sc.SC02;
            String ST02 = sc.ST02;
            String SC03 = sc.SC03;
            String ST03 = sc.ST03;
            String SC04 = sc.SC04;
            String ST04 = sc.ST04;
            String GRP_ID = sc.GRP_ID;

            string SqlWhere = "";
            if (ST01 != null)
            {
                NWS.Where += "[@" + SC01 + "@ = '" + ST01 + "']";
                SqlWhere += " AND " + SC01 + " = '" + ST01 + "'";
            }
            if (ST02 != null)
            {
                NWS.Where += "[@" + SC02 + "@ = '" + ST02 + "']";
                SqlWhere += " AND " + SC02 + " = '" + ST02 + "'";
            }
            if (ST03 != null)
            {
                NWS.Where += "[@" + SC03 + "@ = '" + ST03 + "']";
                SqlWhere += " AND " + SC03 + " = '" + ST03 + "'";
            }
            if (ST04 != null)
            {
                NWS.Where += "[@" + SC04 + "@ = '" + ST04 + "']";
                SqlWhere += " AND " + SC04 + " = '" + ST04 + "'";
            }

            String NSC01 = sc.NSC01;
            String NSC02 = sc.NSC02;
            String NSC03 = sc.NSC03;
            String NSC04 = sc.NSC04;
            String NSC05 = sc.NSC05;
            String NSC06 = sc.NSC06;
            String NST01 = sc.NST01;
            String NST02 = sc.NST02;
            String NST03 = sc.NST03;
            String NST04 = sc.NST04;
            String NST05 = sc.NST05;
            String NST06 = sc.NST06;

            if (NST01 != null)
            {
                NWS.Where += "[@" + NSC01 + "@ = '" + NST01 + "']";
                SqlWhere += " AND " + NSC01 + " = '" + NST01 + "'";
            }
            if (NST02 != null)
            {
                NWS.Where += "[@" + NSC02 + "@ = '" + NST02 + "']";
                SqlWhere += " AND " + NSC02 + " = '" + NST02 + "'";
            }
            if (NST03 != null)
            {
                NWS.Where += "[@" + NSC03 + "@ = '" + NST03 + "']";
                SqlWhere += " AND " + NSC03 + " = '" + NST03 + "'";
            }
            if (NST04 != null)
            {
                NWS.Where += "[@" + NSC04 + "@ = '" + NST04 + "']";
                SqlWhere += " AND " + NSC04 + " = '" + NST04 + "'";
            }
            if (NST05 != null)
            {
                NWS.Where += "[@" + NSC05 + "@ = '" + NST05 + "']";
                SqlWhere += " AND " + NSC05 + " = '" + NST05 + "'";
            }
            if (NST06 != null)
            {
                NWS.Where += "[@" + NSC06 + "@ = '" + NST06 + "']";
                SqlWhere += " AND " + NSC06 + " = '" + NST06 + "'";
            }

            ScTemp.IsSearch = true;
            ScTemp.NWS = NWS;
            ScTemp.CFN = sc.CFN;
            ScTemp.MID = sc.MID;
            ScTemp.TID = sc.TID;
            ScTemp.SC01 = SC01;
            ScTemp.ST01 = ST01;
            ScTemp.SC02 = SC02;
            ScTemp.ST02 = ST02;
            ScTemp.SC03 = SC03;
            ScTemp.ST03 = ST03;
            ScTemp.SC04 = SC04;
            ScTemp.ST04 = ST04;
            ScTemp.NST01 = NST01;
            ScTemp.NST02 = NST02;
            ScTemp.NST03 = NST03;
            ScTemp.NST04 = NST04;
            ScTemp.NST05 = NST05;
            ScTemp.NST06 = NST06;
            ScTemp.GRP_ID = GRP_ID;
            ScTemp.WHERE = SqlWhere;
            WebManagement.Models._Searching.Searching = ScTemp;

            return Json(ScTemp);
        }

        public void LoadMenu()
        {
            MenuList model = new MenuList();
            // var path = System.IO.Path.Combine(contentRootPath, "ManagementConfig/config/desktop.xml");
            #region LoadMenu

            var path = System.IO.Path.Combine(contentRootPath, "ManagementConfig/config/desktop.xml");
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);

            string[] MENU_LIST = { };
            String _PositionCode = IHttpCtAcs.HttpContext.Session.GetString("Position");
            if (_PositionCode != "001")
            {
                NWS = new NextwaverDB.NWheres();
                NWS.Add(new NextwaverDB.NWhere("POSITION_CODE", _PositionCode));

                NCS_S = new NextwaverDB.NColumns();
                NCS_S.Add(new NextwaverDB.NColumn("MENU"));
 
                String NCS_Encrypt = sv.Encrypt(NCS_S.ExportString());
                String NWS_Encrypt = sv.Encrypt(NWS.ExportString());

                String url = Configuration["APIService:url"] + "SelectByColumnAndWhere?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=Position&NColumns_encrypt=" + NCS_Encrypt + "&NWheres_encrypt=" + NWS_Encrypt + "&User=system";
                DataTable dt = sv.ConvertJsonToDatatableLinq(sv.CallAPI(url, "GET"));

                MENU_LIST = ("" + dt.Rows[0][0]).Split(new char[] { ',' });
            }

            XmlNodeList listMenu = xDoc.SelectNodes("//config/menus");

            string Active = ""; //string Active = Request.Params["Active"];
            if (Active == "") Active = "1";
            for (int i = 0; i < listMenu.Count; i++)
            {
                //ID="1" Name="Demo" Icon="menu-icon fa fa-tachometer" Path=""
                string ID = listMenu[i].Attributes["ID"].Value;
                string Name = listMenu[i].Attributes["Name"].Value;
                string Icon = listMenu[i].Attributes["Icon"].Value;
                string MType = listMenu[i].Attributes["Type"].Value;

                Menu m = new Menu();
                m.ID = listMenu[i].Attributes["ID"].Value;
                m.Name = listMenu[i].Attributes["Name"].Value;
                m.Icon = listMenu[i].Attributes["Icon"].Value;
                //    m.Class = "dropdown-toggle";    //insert
                //    m.IsSub = "1";                  //insert

                if (i == 1)
                {
                    m.Active = "active";
                }


                Boolean isAccess = true;
                if (MENU_LIST.Length > 0)
                {
                    isAccess = false;
                    for (int z = 0; z < MENU_LIST.Length; z++)
                    {
                        if (MENU_LIST[z] == ID)
                        {
                            isAccess = true;
                        }
                    }
                }
 
                if (isAccess)
                {
                    SubMenu sm = new SubMenu();
                    SubMenuList smList = new SubMenuList();
                    if (MType.ToUpper() == "URL")
                    {
                        string URL = "";
                        try
                        {
                            URL = listMenu[i].Attributes["Url"].Value;
                        }
                        catch { }
                        //  SMenu += ",\"PATH\":\"" + URL + "\"";
                        m.Path = URL;
                        //{{x.PATH}}?ID={{ x.ID }}

                        XmlNodeList SubNode = listMenu[i].SelectNodes("./menu");
                        for (int j = 0; j < SubNode.Count; j++)
                        {
                            //Name="Demo2" Icon="menu-icon fa fa-desktop" Url="../page/management.aspx"
                            string SubName = SubNode[j].Attributes["Name"].Value;
                            string SubIcon = SubNode[j].Attributes["Icon"].Value;
                            string SubUrl = SubNode[j].Attributes["Url"].Value;
                            string SubID = SubNode[j].Attributes["ID"].Value;

                            isAccess = true;
                            if (MENU_LIST.Length > 0)
                            {
                                isAccess = false;
                                for (int z = 0; z < MENU_LIST.Length; z++)
                                {
                                    if (MENU_LIST[z] == SubID)
                                    {
                                        isAccess = true;
                                        break;
                                    }
                                }
                            }
                            sm = new SubMenu();
                            if (isAccess)
                            {
                                // if (SubMenu == "")
                                //     SubMenu = "{";
                                // else
                                //     SubMenu += ",{";
                                //
                                // SubMenu += "\"ID\":\"" + SubID + "\"";
                                // SubMenu += ",\"NAME\":\"" + SubName + "\"";
                                // SubMenu += ",\"PATH\":\"" + SubUrl + "\"";
                                //
                                // SubMenu += ",\"CLASS\":\"\"";
                                // SubMenu += ",\"ISSUB\":\"0\"";
                                // SubMenu += "}";
                                sm.ID = SubID;
                                sm.Name = SubName;
                                sm.Path = "";
                                sm.Class = "";
                                sm.IsSub = "0";
                                smList.SubMenu.Add(sm);

                            }
                        }
                    }
                    else
                    {
                        string ManagementName = listMenu[i].Attributes["ManagementName"].Value;

                        XmlDocument xManage = new XmlDocument();
                        xManage.Load(System.IO.Path.Combine(contentRootPath, "ManagementConfig/config/" + ManagementName + ".xml"));

                        XmlNodeList listView = xManage.SelectNodes("//Config/Views/View");

                        smList = new SubMenuList();
                        m.SubMenuList.Add(smList);

                        for (int z = 0; z < listView.Count; z++)
                        {
                            sm = new SubMenu();
                            sm.ID = "XXXX";
                            sm.Name = listView[z].Attributes["Name"].Value;
                            sm.Path = "";                  //insert
                                                           //   sm.Class = "dropdown-toggle";  //insert
                                                           //   sm.IsSub = "1";                //insert
                                                           //   smList.SubMenu.Add(sm);

                            XmlNodeList listItem = listView[z].SelectNodes("./Item");
                            SubMenuLast smLast = new SubMenuLast();
                            for (int y = 0; y < listItem.Count; y++)
                            {
 
                                string IconID = listItem[y].Attributes["IconID"].Value;
                                string sName = listItem[y].Attributes["Name"].Value;
                                string MappingID = listItem[y].Attributes["MappingID"].Value;
                                string SubItemID = ID + "-" + z + "-" + y;
 
                                if (MENU_LIST.Length > 0)
                                {
                                    isAccess = false;
                                    for (int n = 0; n < MENU_LIST.Length; n++)
                                    {
                                        if (SubItemID.Replace("-", ".") == "0.1.1")
                                        {

                                        }
                                        else if (MENU_LIST[n] == SubItemID.Replace("-", "."))
                                        {
                                            isAccess = true;
                                            break;
                                        }
                                    }
                                }
                                if (isAccess)
                                {
                                    XmlNode nodeMapping = xManage.SelectSingleNode("//Config/Mappings/Mapping[@ID='" + MappingID + "']");
                                    string MID = nodeMapping.Attributes["ManagementID"].Value;
                                    string TID = nodeMapping.Attributes["ToolID"].Value;


                                    smLast = new SubMenuLast();
                                    smLast.ID = ID + "-" + z + "-" + y;
                                    smLast.Name = listItem[y].Attributes["Name"].Value;
                                    smLast.Path = "";
                                    smLast.ConfigName = ManagementName;
                                    smLast.ManagementID = MID;
                                    smLast.ToolID = TID;
                                    smLast.Path = "";
                                    smLast.Active = "active open";   //insert

                                    sm.SubMenuLast.Add(smLast);
                                }
                            }
                            //  SubMenu += ",\"SUBMENU\":[" + SubMenuItem + "]";
                            //
                            //  if (SubMenuItem == "")
                            //  {
                            //      SubMenu += ",\"CLASS\":\"\"";
                            //      SubMenu += ",\"ISSUB\":\"0\"";
                            //  }
                            //  else
                            //  {
                            //      SubMenu += ",\"CLASS\":\"dropdown-toggle\"";
                            //      SubMenu += ",\"ISSUB\":\"1\"";
                            //  }
                            //
                            //  SubMenu += "}";
                            if (smLast.ID == null)
                            {
                                sm.Class = "";
                                sm.IsSub = "0";
                            }
                            else
                            {
                                sm.Class = "dropdown-toggle";
                                sm.IsSub = "1";
                            }
                            smList.SubMenu.Add(sm);
                        }

                    }


                    //   if (SubMenu == "")
                    //   {
                    //       SMenu += ",\"CLASS\":\"\"";
                    //       SMenu += ",\"ISSUB\":\"0\"";
                    //   }
                    //   else
                    //   {
                    //       SMenu += ",\"CLASS\":\"dropdown-toggle\"";
                    //       SMenu += ",\"ISSUB\":\"1\"";
                    //   }
                    //   if (ID == Active)
                    //       SMenu += ",\"ACTIVE\":\"active\"";
                    //   else
                    //       SMenu += ",\"ACTIVE\":\"\"";
                    //
                    //   SMenu += ",\"SUBMENU\":[" + SubMenu + "]";
                    //
                    //   SMenu += "}";
                    if (sm.ID == null)
                    {
                        m.Class = "";
                        m.IsSub = "0";
                    }
                    else
                    {
                        m.Class = "dropdown-toggle";
                        m.IsSub = "1";
                    }

                    if (ID == Active)
                    {
                        m.Active = "active";
                    }
                    else
                    {
                        m.Active = "";
                    }
                    model.Menu.Add(m);
                }
            }

            LoadMenuManage("");
            WebManagement.Models.MenuConfigs.MenuConfig = model;
            #endregion

        }

        private void LoadManagement(String CFN, String MID, String TID, Searching SC)
        {
            var path = System.IO.Path.Combine(contentRootPath, "ManagementConfig/config/desktop.xml");
            xDoc.Load("ManagementConfig/config/" + CFN + ".xml");

            XmlNode nodeManagement = xDoc.SelectSingleNode("//Config/Managements/Management[@ID='" + MID + "']");
            MC.Title = nodeManagement.SelectSingleNode("./Headers").Attributes["Title"].Value;
            XmlNodeList listColumn = nodeManagement.SelectNodes("./Table/Column");

            for (int j = 0; j < listColumn.Count; j++)
            {
                // <Column Name="ID" Text="ลำดับ" Width="70" Format="xxx" Visible="T" DataAlign="D" ColumnAlign="D" FixedColumn="F" />
                string CN = listColumn[j].Attributes["Name"].Value.ToUpper();
                string TXT = listColumn[j].Attributes["Text"].Value;
                bool Visible = strToBool(listColumn[j].Attributes["Visible"].Value);
                bool Fiexed = strToBool(listColumn[j].Attributes["FixedColumn"].Value);
                string Width = listColumn[j].Attributes["Width"].Value;

                if (Visible)
                {
                    cls = new Columns();
                    cls.Name = CN;
                    cls.Text = TXT;
                    cls.Width = Width;
                    if (j > 1)
                        cls.Class = "hidden-480";
                    else
                        cls.Class = "center";

                    MC.Columns.Add(cls);
                }
            }

            DataTable dtTemp;
            string Type = nodeManagement.Attributes["Type"].Value;
            MC.PageDisplay = "10";
            string SGroupTxt = "";
            string sGroupColumn = "";
            string sGroupValue = "";
            if (Type.ToUpper() == "OFFICE")
            {
                XmlNode nodeNextwaverDB = nodeManagement.SelectSingleNode("./NextwaverDB");
                string Connection = nodeNextwaverDB.Attributes["Connection"].Value;
                string DatabaseName = nodeNextwaverDB.Attributes["DatabaseName"].Value;
                string TableName = nodeNextwaverDB.Attributes["TableName"].Value;

                //<Group Connection="NextwaverDatabase" DatabaseName="GunBook" TableName="Book" Display="BOOKNO" Value="BOOKNO" Text="เลขหนังสือ"/>
                /*
                XmlNode nodeGroup = nodeManagement.SelectSingleNode("./Group");
                if (nodeGroup != null)
                {
                    string sDisplay = nodeGroup.Attributes["Display"].Value;
                    string sValue = nodeGroup.Attributes["Value"].Value;
                    sGroupColumn = sValue;
                    SGroupTxt = nodeGroup.Attributes["Text"].Value;
                    NCS_S = new NextwaverDB.NColumns();
                    NCS_S.Add(new NextwaverDB.NColumn(sDisplay));


                    if (sDisplay != sValue)
                        NCS_S.Add(new NextwaverDB.NColumn(sValue));

                    String url = Configuration["APIService:url"] + "SelectAllByColumn?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + nodeGroup.Attributes["DatabaseName"].Value + "&TableName=" + nodeGroup.Attributes["TableName"].Value + "&NColumns_String=" + NCS_S.ExportString() + "&User=";
                    dtTemp = sv.ConvertJsonToDatatableLinq(sv.CallAPI(url, "GET"));

                    if (SC.IsSearch) sGroupValue = SC.GRP_ID;

                    if (nodeGroup.Attributes["DatabaseName"].Value == "GunBook" && nodeGroup.Attributes["TableName"].Value == "Book")
                    {
                        DataTable dtCloned = dtTemp.Clone();
                        dtCloned.Columns[0].DataType = typeof(Int32);
                        foreach (DataRow row in dtTemp.Rows)
                        {
                            dtCloned.ImportRow(row);
                        }

                        DataView dv = dtCloned.DefaultView;
                        dv.Sort = "BOOKNO";
                        dtTemp = dv.ToTable();
                    }

                    for (int i = 0; i < dtTemp.Rows.Count; i++)
                    {
                        if (sGroupValue == "") sGroupValue = "" + dtTemp.Rows[i][sValue];

                        grp = new Group();
                        grp.Value = Convert.ToString(dtTemp.Rows[i][sValue]);
                        grp.Value = Convert.ToString(dtTemp.Rows[i][sDisplay]);
                        grp.Value = sGroupValue;
                        MC.Group.Add(grp);
                    }
                }
                */
                XmlNode nodePageDisplay = nodeManagement.SelectSingleNode("./PageDisplay");

                if (nodePageDisplay != null) MC.PageDisplay = nodePageDisplay.InnerText;

                XmlNodeList listWhere = nodeManagement.SelectNodes("./Wheres/Where");
                if (listWhere.Count == 0)
                {
                    if (!SC.IsSearch)
                    {
                        if (sGroupColumn == "")
                        {
                            String url = Configuration["APIService:url"] + "SelectAll?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=" + TableName + "&User=System";
                            dtTemp = sv.ConvertJsonToDatatableLinq(sv.CallAPI(url, "GET"));
                        }
                        else
                        {
                            NWS = new NextwaverDB.NWheres();
                            NWS.whereType = true;
                            NWS.Where = "";
                            NWS.Where += "[@" + sGroupColumn + "@ = '" + sGroupValue + "']";
                            //     string NWS_Encrypt = new EncryptDecrypt.CryptorEngine().Encrypt(NWS.ExportString(), true);
                            string NWS_Encrypt = sv.Encrypt(NWS.ExportString());
                            String url = Configuration["APIService:url"] + "SelectAllColumnByWhere?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=" + TableName + "&NWheres_String=" + NWS.ExportString() + "&User=system";
                            dtTemp = sv.ConvertJsonToDatatableLinq(sv.CallAPI(url, "GET"));
                        }
                    }
                    else
                    {
                        NextwaverDB.NWheres NWS = SC.NWS;

                        if (NWS == null)
                        {
                            if (sGroupColumn == "")
                            {
                                String url = Configuration["APIService:url"] + "SelectAll?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=" + TableName + "&User=system";
                                dtTemp = sv.ConvertJsonToDatatableLinq(sv.CallAPI(url, "GET"));
                            }
                            else
                            {
                                NWS = new NextwaverDB.NWheres();
                                NWS.whereType = true;
                                NWS.Where = "";
                                NWS.Where += "[@" + sGroupColumn + "@ = '" + sGroupValue + "']";
                                //  string NWS_Encrypt = new EncryptDecrypt.CryptorEngine().Encrypt(NWS.ExportString(), true);
                                string NWS_Encrypt = sv.Encrypt(NWS.ExportString());
                                String url = Configuration["APIService:url"] + "SelectAllColumnByWhere?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=" + TableName + "&NWheres_String=" + NWS.ExportString() + "&User=system";
                                dtTemp = sv.ConvertJsonToDatatableLinq(sv.CallAPI(url, "GET"));
                            }
                        }
                        else
                        {
                            if (sGroupColumn == "")
                            {
                                //  string NWS_Encrypt = new EncryptDecrypt.CryptorEngine().Encrypt(NWS.ExportString(), true);
                                string NWS_Encrypt = sv.Encrypt(NWS.ExportString());
                                String url = Configuration["APIService:url"] + "SelectAllColumnByWhere?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=" + TableName + "&NWheres_String=" + NWS.ExportString() + "&User=system";
                                dtTemp = sv.ConvertJsonToDatatableLinq(sv.CallAPI(url, "GET"));
                            }
                            else
                            {
                                NWS.Where += "[@" + sGroupColumn + "@ = '" + sGroupValue + "']";
                                //  string NWS_Encrypt = new EncryptDecrypt.CryptorEngine().Encrypt(NWS.ExportString(), true);
                                string NWS_Encrypt = sv.Encrypt(NWS.ExportString());


                                String url = Configuration["APIService:url"] + "SelectAllColumnByWhere?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=" + TableName + "&NWheres_String=" + NWS.ExportString() + "&User=system";
                                dtTemp = sv.ConvertJsonToDatatableLinq(sv.CallAPI(url, "GET"));
                            }
                        }
                    }
                }
                else
                {
                    NWS = new NextwaverDB.NWheres();
                    NWS.whereType = true;
                    NWS.Where = "";
                    if (SC.IsSearch) NWS = SC.NWS;

                    for (int i = 0; i < listWhere.Count; i++)
                    {
                        string tmpColumn = listWhere[i].Attributes["Column"].Value;
                        string tmpOperation = listWhere[i].Attributes["Operation"].Value;
                        string tmpValue = listWhere[i].Attributes["Value"].Value;
                        NWS.Where += "[@" + tmpColumn + "@ " + tmpOperation + " '" + tmpValue + "']";
                    }

                    if (sGroupColumn != "")
                        NWS.Where += "[@" + sGroupColumn + "@ = '" + sGroupValue + "']";

                    if (SC.IsSearch)
                    {
                        NextwaverDB.NWheres NWS2 = SC.NWS;

                        if (NWS2 != null)
                            NWS.Where += NWS2.Where;
                    }
                    //   string NWS_Encrypt = new EncryptDecrypt.CryptorEngine().Encrypt(NWS.ExportString(), true);
                    string NWS_Encrypt = sv.Encrypt(NWS.ExportString());

                    String url = Configuration["APIService:url"] + "SelectAllColumnByWhere?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=" + TableName + "&NWheres_String=" + NWS.ExportString() + "&User=system";
                    dtTemp = sv.ConvertJsonToDatatableLinq(sv.CallAPI(url, "GET"));

                }
            }
            else
            {
                XmlNode nodeConnection = nodeManagement.SelectSingleNode("./Connection/Item");
                string ServerName = nodeConnection.Attributes["Server"].Value;
                string Database = nodeConnection.Attributes["Database"].Value;
                string Login = nodeConnection.Attributes["Login"].Value;
                string Password = nodeConnection.Attributes["Password"].Value;
                string strConnect = "Data Source=@Source; uid=@Uid; pwd=@Pass; Initial Catalog=@Database;";
                strConnect = strConnect.Replace("@Source", ServerName);
                strConnect = strConnect.Replace("@Uid", Login);
                strConnect = strConnect.Replace("@Pass", Password);
                strConnect = strConnect.Replace("@Database", Database);

                XmlNode nodeGroup = nodeManagement.SelectSingleNode("./Group");
                if (nodeGroup != null)
                {
                    string sDisplay = nodeGroup.Attributes["Display"].Value;
                    string sValue = nodeGroup.Attributes["Value"].Value;
                    sGroupColumn = sValue;
                    SGroupTxt = nodeGroup.Attributes["Text"].Value;
                    string Sql_group = nodeGroup.InnerText;

                    dtTemp = sv.Retreive(Sql_group, strConnect);

                    for (int i = 0; i < dtTemp.Rows.Count; i++)
                    {
                        if (sGroupValue == "") sGroupValue = "" + dtTemp.Rows[i][sValue];

                        grp = new Group();
                        grp.Value = Convert.ToString(dtTemp.Rows[i][sValue]);
                        grp.Value = Convert.ToString(dtTemp.Rows[i][sDisplay]);
                        grp.Value = sGroupValue;
                        MC.Group.Add(grp);

                    }
                }
                string Query = nodeManagement.SelectSingleNode("./Query/SQL[@ID='Main']").InnerText;
                string SWhere = SC.WHERE;

                Query = Query + SWhere;
                //  NWS.Where += "[@" + sGroupColumn + "@ = '" + sGroupValue + "']";
                if (sGroupColumn != "")
                {
                    Query = Query + " AND " + sGroupColumn + " = '" + sGroupValue + "'";
                }

                string GroupBy = "";
                try { GroupBy = nodeManagement.SelectSingleNode("./Query/SQL[@ID='Group']").InnerText; } catch { }

                Query = Query + " " + GroupBy;

                dtTemp = sv.Retreive(Query, strConnect);
            }

            try
            {
                if (dtTemp != null)
                {
                    for (int i = 0; i < dtTemp.Rows.Count; i++)
                    {
                        rcs = new Records();
                        rcs.RowID = i.ToString();

                        DataRow dr = dtTemp.Rows[i];
                        for (int j = 0; j < listColumn.Count; j++)
                        {
                            string CN = listColumn[j].Attributes["Name"].Value.ToUpper();
                            bool Visible = strToBool(listColumn[j].Attributes["Visible"].Value);
                            string CV = dr[CN].ToString();
                            CV = CV.Replace("'", "");
                            string ClassStatus = "";

                            if (CN.ToString() == "STATUS")
                            {
                                string[] SP = CV.Split(new char[] { ' ' });
                                switch (SP[0])
                                {
                                    case "1": ClassStatus = "label label-lg label-success arrowed-in arrowed-in-right"; break; // SUCESS
                                    case "2": ClassStatus = "label label-lg label-yellow arrowed-in arrowed-in-right"; break; // WARNING
                                    case "3": ClassStatus = "label label-lg label-danger arrowed-in arrowed-in-right"; break; // DANGER
                                    case "4": ClassStatus = "label label-lg label-info arrowed-in arrowed-in-right"; break; // INFO
                                    case "5": ClassStatus = "label label-lg label-inverse arrowed-in arrowed-in-right"; break; // BLACK
                                    case "6": ClassStatus = "label label-lg label-purple arrowed-in arrowed-in-right"; break; // PURPLE
                                    case "7": ClassStatus = "label label-lg label-pink arrowed-in arrowed-in-right"; break; // PINK
                                    case "8": ClassStatus = "label label-lg label-grey arrowed-in arrowed-in-right"; break; // grey
                                }
                            }

                            cl = new Column();
                            cl.Name = CN;
                            cl.Value = CV;

                            if (Visible)
                                if (j > 1)
                                    cl.Class = "hidden-480";
                                else
                                    cl.Class = "center";
                            else
                                cl.Class = "hidden";

                            cl.ClassStatus = ClassStatus;

                            rcs.Column.Add(cl);
                        }
                        MC.Records.Add(rcs);
                    }
                }
            }
            catch { }

            XmlNodeList listTool = xDoc.SelectNodes("//Config/Tools/Tool[@ID='" + TID + "']/Item");
            for (int i = 0; i < listTool.Count; i++)
            {
                //<Item Name="Add" Type="SB" Visible="F" DisplayStyle="IAT" Text="เพิ่มผู้ใช้งาน" Tooltiptext="เพิ่มผู้ใช้งาน" Click="AddUser" Image="1" S_Enable="S:0:1:2:3:4:5:6:7:8:9" S_Visible="S:0:1:2:3:4:5:6:7:8:9"/>
                string Name = listTool[i].Attributes["Name"].Value;
                bool Visible = strToBool(listTool[i].Attributes["Visible"].Value);
                string Image = listTool[i].Attributes["Image"].Value;
                string Text = listTool[i].Attributes["Text"].Value;
                string Click = listTool[i].Attributes["Click"].Value;
                string Tooltiptext = listTool[i].Attributes["Tooltiptext"].Value;

                if (Visible)
                {
                    tls = new Tools();
                    tls.Name = Name;
                    tls.Image = "ace-icon fa " + Image + " align-top bigger-125";
                    tls.Text = Text;
                    tls.Click = Click;
                    tls.ToolID = TID;
                    tls.ConfigName = Name;
                    tls.ToolTip = CFN;
                    tls.Index = i.ToString();
                    MC.Tools.Add(tls);
                }
            }

            XmlNodeList listSearch = nodeManagement.SelectNodes("./Searchs/Search");

            int ColumnIndex = 1;
            for (int i = 0; i < listSearch.Count; i++)
            {
                string FiledName = listSearch[i].Attributes["FiledName"].Value;
                string Title = listSearch[i].Attributes["Text"].Value;
                string SearchType = listSearch[i].Attributes["Type"].Value;

                if (FiledName != "")
                {
                    string CINDEX = "1";
                    for (int j = 0; j < listColumn.Count; j++)
                    {
                        string CName = listColumn[j].Attributes["Name"].Value;
                        if (CName == FiledName)
                            CINDEX = "" + (j + 1);
                    }

                    srch = new Search();
                    srch.Name = FiledName;
                    srch.Title = Title;

                    /*
                    if (SC.IsSearch)
                    {
                        NextwaverDB.NWheres NWS = SC.NWS;
                        if (NWS != null)
                        {
                            //    SSearchColumn += ",\"VAL1\":\"" + Session[MID + "SC01" + SRD] + "\"";
                            //    SSearchColumn += ",\"VAL2\":\"" + Session[MID + "SC02" + SRD] + "\"";
                            //    SSearchColumn += ",\"VAL3\":\"" + Session[MID + "SC03" + SRD] + "\"";
                            //    SSearchColumn += ",\"VAL4\":\"" + Session[MID + "SC04" + SRD] + "\"";
                        }
                    }
                    */
                    MC.Search.Add(srch);
                    ColumnIndex++;
                }
            }

            string NV1 = SC.NST01;
            string NV2 = SC.NST02;
            string NV3 = SC.NST03;
            string NV4 = SC.NST04;
            string NV5 = SC.NST05;
            string NV6 = SC.NST06;

            XmlNodeList listSearchLike = nodeManagement.SelectNodes("./SearchLike/Search");
            for (int i = 0; i < listSearchLike.Count; i++)
            {
                string FiledName = listSearchLike[i].Attributes["FiledName"].Value;
                string Title = listSearchLike[i].Attributes["Text"].Value;
                string SearchType = listSearchLike[i].Attributes["Type"].Value;

                switch (i)
                {
                    case 0:
                        MC.NFN1 = FiledName;
                        MC.NT1 = Title;
                        break;
                    case 1:
                        MC.NFN2 = FiledName;
                        MC.NT2 = Title;
                        break;
                    case 2:
                        MC.NFN3 = FiledName;
                        MC.NT3 = Title;
                        break;
                    case 3:
                        MC.NFN4 = FiledName;
                        MC.NT4 = Title;
                        break;
                    case 4:
                        MC.NFN5 = FiledName;
                        MC.NT5 = Title;
                        break;
                    case 5:
                        MC.NFN6 = FiledName;
                        MC.NT6 = Title;
                        break;
                }
            }
            MC.NV1 = NV1;
            MC.NV2 = NV2;
            MC.NV3 = NV3;
            MC.NV4 = NV4;
            MC.NV5 = NV5;
            MC.NV6 = NV6;

            string ST1 = SC.ST01;
            string ST2 = SC.ST02;
            string ST3 = SC.ST03;
            string ST4 = SC.ST04;

            MC.ST1 = ST1;
            MC.ST2 = ST2;
            MC.ST3 = ST3;
            MC.ST4 = ST4;

            MC.GroupText = SGroupTxt;
            MC.GroupValue = sGroupValue;
            MC.nSearchCount = listSearchLike.Count.ToString();

            ManagementActive MA = new ManagementActive();
            MA.TabName = "ผู้ใช้งาน";
            MC.ManagementActive.Add(MA);

            //  MLC = new ManagementListConfig();
            //  MLC.ManagementConfig.Add(MC);

            //    WebManagement.Models.ManagementConfigs.ManagementListConfig = MLC;
            // if (SC.IsSearch) WebManagement.Models._Searching.Searching.IsSearch = false;

            WebManagement.Models._ManagementConfigs.ManagementConfig = MC;
        }
 
        public void LoadMenuManage(String Active)
        {
            MenuList model = new MenuList();

            string[] tmpMENU = null;

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(System.IO.Path.Combine(contentRootPath, "ManagementConfig/config/desktop.xml"));


            XmlNodeList listMenu = xDoc.SelectNodes("//config/menus");
            string SMenu = "";

            if (Active == "") Active = "1";

            for (int i = 0; i < listMenu.Count; i++)
            {
                //ID="1" Name="Demo" Icon="menu-icon fa fa-tachometer" Path=""
                string ID = listMenu[i].Attributes["ID"].Value;
                string Name = listMenu[i].Attributes["Name"].Value;
                string Icon = listMenu[i].Attributes["Icon"].Value;
                string MType = listMenu[i].Attributes["Type"].Value;

                //    if (SMenu == "")
                //        SMenu = "{";
                //    else
                //        SMenu += ",{";
                //
                //    SMenu += "\"ID\":\"" + ID + "\"";
                //    SMenu += ",\"NAME\":\"" + Name + "\"";
                //    SMenu += ",\"ICON\":\"" + Icon + "\"";
                //    SMenu += ",\"CHECK\":\"" + checkMENU(tmpMENU, ID) + "\"";


                Menu m = new Menu();
                m.ID = ID;
                m.Name = Name;
                m.Icon = Icon;
                m.Check = checkMENU(tmpMENU, ID);


                //SMenu += ",\"URL\":\"main.htm?ID=" + ID + "\"";
                string SubMenu = "";
                SubMenuList smList = new SubMenuList();
                if (MType.ToUpper() == "URL")
                {
                    string URL = "";
                    try
                    {
                        URL = listMenu[i].Attributes["Url"].Value;
                    }
                    catch { }
                    //   SMenu += ",\"PATH\":\"" + URL + "\"";
                    //{{x.PATH}}?ID={{ x.ID }}
                    m.Path = URL;

                    XmlNodeList SubNode = listMenu[i].SelectNodes("./menu");
                    for (int j = 0; j < SubNode.Count; j++)
                    {
                        //Name="Demo2" Icon="menu-icon fa fa-desktop" Url="../page/management.aspx"
                        string SubName = SubNode[j].Attributes["Name"].Value;
                        string SubIcon = SubNode[j].Attributes["Icon"].Value;
                        string SubUrl = SubNode[j].Attributes["Url"].Value;
                        string SubID = SubNode[j].Attributes["ID"].Value;

                        // if (SubMenu == "")
                        //     SubMenu = "{";
                        // else
                        //     SubMenu += ",{";
                        //
                        // SubMenu += "\"ID\":\"" + ID + "." + j + "\"";
                        // SubMenu += ",\"NAME\":\"" + SubName + "\"";
                        // SubMenu += ",\"PATH\":\"" + SubUrl + "\"";
                        //
                        // SubMenu += ",\"CLASS\":\"\"";
                        // SubMenu += ",\"ISSUB\":\"0\"";
                        // SubMenu += ",\"CHECK\":\"" + checkMENU(tmpMENU, ID) + "\"";
                        //
                        // SubMenu += "}";

                        SubMenu sm = new SubMenu();
                        sm.ID = ID;
                        sm.Name = SubMenu;
                        sm.Path = SubUrl;
                        sm.Class = "";
                        sm.IsSub = "0";
                        sm.Check = checkMENU(tmpMENU, ID);
                        smList._SubMenu.Add(sm);
                    }
                }
                else
                {
                    string ManagementName = listMenu[i].Attributes["ManagementName"].Value;
                    SMenu += ",\"PATH\":\"management.aspx?ID=" + ID + "&ConfigName=" + ManagementName + "\"";

                    XmlDocument xManage = new XmlDocument();
                    // xManage.Load(Server.MapPath("config/" + ManagementName + ".xml"));
                    xManage.Load(System.IO.Path.Combine(contentRootPath, "ManagementConfig/config/" + ManagementName + ".xml"));

                    XmlNodeList listView = xManage.SelectNodes("//Config/Views/View");
                    for (int z = 0; z < listView.Count; z++)
                    {
                        string SubName = listView[z].Attributes["Name"].Value;
                        string SubEnable = listView[z].Attributes["Enable"].Value;

                        //  if (SubMenu == "")
                        //      SubMenu = "{";
                        //  else
                        //      SubMenu += ",{";
                        //
                        //  SubMenu += "\"ID\":\"" + ID + "." + z + "\"";
                        //  SubMenu += ",\"NAME\":\"" + SubName + "\"";
                        //  SubMenu += ",\"PATH\":\"\"";
                        //  SubMenu += ",\"CHECK\":\"" + checkMENU(tmpMENU, ID + "." + z) + "\"";

                        SubMenu sm = new SubMenu();
                        sm.ID = ID + "." + z;
                        sm.Name = SubName;
                        sm.Path = "";
                        sm.Class = "";
                        sm.Check = checkMENU(tmpMENU, ID + "." + z);
                        smList._SubMenu.Add(sm);


                        XmlNodeList listItem = listView[z].SelectNodes("./Item");
                        //  string SubMenuItem = "";
                        for (int y = 0; y < listItem.Count; y++)
                        {
                            string IconID = listItem[y].Attributes["IconID"].Value;
                            string sName = listItem[y].Attributes["Name"].Value;
                            string MappingID = listItem[y].Attributes["MappingID"].Value;
                            string SubItemID = ID + "." + z + "." + y;

                            XmlNode nodeMapping = xManage.SelectSingleNode("//Config/Mappings/Mapping[@ID='" + MappingID + "']");
                            // <Mapping ID="1" Name="Users" RowID="E" ManagementID="Management1" ToolID="Tools1" ThemeID="Theme1" ParameterID="Parameter1" />
                            string MID = nodeMapping.Attributes["ManagementID"].Value;
                            string TID = nodeMapping.Attributes["ToolID"].Value;

                            //     if (SubMenuItem == "")
                            //         SubMenuItem = "{";
                            //     else
                            //         SubMenuItem += ",{";
                            //
                            //     SubMenuItem += "\"ID\":\"" + SubItemID + "\"";
                            //     SubMenuItem += ",\"NAME\":\"" + sName + "\"";
                            //     SubMenuItem += ",\"PATH\":\"management.aspx?ID=" + SubItemID + "&CFN=" + ManagementName /+ /"&MID=" + MID + "&TID=" + TID + "\"";
                            //     if (SubItemID == Active)
                            //     {
                            //         Active = ID;
                            //         SubMenu += ",\"ACTIVE\":\"active open\"";
                            //         SubMenuItem += ",\"ACTIVE\":\"active\"";
                            //     }
                            //     else
                            //         SubMenuItem += ",\"ACTIVE\":\"\"";
                            //
                            SubMenuLast smLast = new SubMenuLast();
                            smLast.ID = SubItemID;
                            smLast.Name = sName;
                            smLast.Path = "";

                            if (SubItemID == Active)
                            {
                                Active = ID;
                                m.Active = "active open";
                                smLast.Active = "active";
                            }
                            else
                                smLast.Active = "";


                            sm.Check = checkMENU(tmpMENU, SubItemID);

                            // SubMenuItem += ",\"CHECK\":\"" + checkMENU(tmpMENU, SubItemID) + "\"";
                            // SubMenuItem += "}";
                            sm.SubMenuLast.Add(smLast);
                        }
                        //    SubMenu += ",\"SUBMENU\":[" + SubMenuItem + "]";

                        //
                        //  if (SubMenuItem == "")
                        //  {
                        //      SubMenu += ",\"CLASS\":\"\"";
                        //      SubMenu += ",\"ISSUB\":\"0\"";
                        //  }
                        //  else
                        //  {
                        //      SubMenu += ",\"CLASS\":\"dropdown-toggle\"";
                        //      SubMenu += ",\"ISSUB\":\"1\"";
                        //  }
                        // SubMenu += "}";
                        if (listItem.Count == 0)
                        {
                            sm.Class = "";
                            sm.IsSub = "0";
                        }
                        else
                        {
                            sm.Class = "dropdown-toggle";
                            sm.IsSub = "1";
                        }

                    }
                    if (listView.Count == 0)
                    {
                        m.Class = "";
                        m.IsSub = "0";
                    }
                    else
                    {
                        m.Class = "dropdown-toggle";
                        m.IsSub = "1";
                    }
                    if (ID == Active)
                        m.Active = "active";
                    else
                        m.Active = "";

                    m.SubMenuList.Add(smList);
                }
                model.Menu.Add(m);
                WebManagement.Models.MenuManage.MenuConfig = model;
                // if (SubMenu == "")
                // {
                //     SMenu += ",\"CLASS\":\"\"";
                //     SMenu += ",\"ISSUB\":\"0\"";
                // }
                // else
                // {
                //     SMenu += ",\"CLASS\":\"dropdown-toggle\"";
                //     SMenu += ",\"ISSUB\":\"1\"";
                // }
                //
                // if (ID == Active)
                //     SMenu += ",\"ACTIVE\":\"active\"";
                // else
                //     SMenu += ",\"ACTIVE\":\"\"";
                //
                // SMenu += ",\"SUBMENU\":[" + SubMenu + "]";
                //
                // SMenu += "}";
            }
            //  return model;
            //return Json(model);
        }

        #region Method
        bool strToBool(string str)
        {
            if (str == "T") return true;
            else return false;
        }
        string checkMENU(string[] SP, string ID)
        {
            if (SP == null) return "0";
            for (int z = 0; z < SP.Length; z++)
            {
                if (SP[z] == ID) return "1";
            }
            return "0";
        }
        #endregion
    }
}