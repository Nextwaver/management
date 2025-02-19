using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using WebManagement.Models;

namespace WebManagement.Controllers
{
    public class ServiceController : Controller
    {
        String Connection = "NextwaverDatabase";
        String OfficeSpaceId = "OF.0001";
        String DatabaseName = "Doc";
        private ErrorMessageModel ms = new ErrorMessageModel();
        public ServiceController(IConfiguration configuration)
        {
            Configuration = configuration;
            var Key = Configuration["WorkSpaceConfig:EncryptKey"];
            var ApiUrl = Environment.GetEnvironmentVariable("serverUrl");
            Configuration["APIService:url"] = ApiUrl;
        }
 
        public IConfiguration Configuration { get; }

        public IActionResult Index()
        {
            return View();
        }

        public ReturnDataTable CallAPI(String url, String MethodType)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/WS/V1/");
            var response = client.GetAsync(url).Result;
            var json = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<ReturnDataTable>(json);
        }
        public DataTable ConvertJsonToDatatableLinq(ReturnDataTable rdt)
        {
            string data = rdt.Data;
            return JsonConvert.DeserializeObject<DataTable>(data);
        }

        public String SCallAPI(String url, String MethodType)
        {
            var client = new RestClient(url);
            var request = new RestRequest();
            if (MethodType == "GET") request = new RestRequest(Method.Get.ToString());
            if (MethodType == "POST") request = new RestRequest(Method.Post.ToString());

            RestResponse response = client.Execute(request);
            String ResultString = response.Content;
            return ResultString;
        }
        public DataTable SConvertJsonToDatatableLinq(string jsonString)
        {
            var jsonLinq = JObject.Parse(jsonString);

            // Find the first array using Linq
            var linqArray = jsonLinq.Descendants().Where(x => x is JArray).First();
            var jsonArray = new JArray();
            foreach (JObject row in linqArray.Children<JObject>())
            {
                var createRow = new JObject();
                foreach (JProperty column in row.Properties())
                {
                    // Only include JValue types
                    if (column.Value is JValue)
                        createRow.Add(column.Name, column.Value);
                }
                jsonArray.Add(createRow);
            }
            return JsonConvert.DeserializeObject<DataTable>(jsonArray.ToString());
        }
        public JObject ConvertJsonStringToJObject(string jsonString)
        {
            JObject json = JObject.Parse(jsonString);
            return json;
        }
 
        [HttpPost]
        public JsonResult DeleteDataByDocID(String ID, String TableName)
        {
            ms = new ErrorMessageModel();
            NextwaverDB.NColumns NCS = new NextwaverDB.NColumns();
            NCS.Add(new NextwaverDB.NColumn("STATUS", "D"));
            NCS.Add(new NextwaverDB.NColumn("UPDATE_DATE", DateTime.Now.ToString("dd/MM/yyyy")));
            NCS.Add(new NextwaverDB.NColumn("UPDATE_BY", "system"));

            NextwaverDB.NWheres NWS = new NextwaverDB.NWheres();
            NWS.Add("ID", ID);

            String url = Configuration["APIService:url"] + "UpdateData?Connection=" + Connection + "&OfficeSpaceId=" + OfficeSpaceId + "&DatabaseName=" + DatabaseName + "&TableName=" + TableName + "&NColumns_String=" + NCS.ExportString() + "&NWheres_String=" + NWS.ExportString() + "&strDOC=&User=system";

            JObject json = ConvertJsonStringToJObject(SCallAPI(url, "POST"));

            ms.Code = json["dataList"][0]["data"].ToString();
            ms.Message = json["dataList"][1]["data"].ToString();

            return Json(ms);
        }
        public XmlDocument AddDataXmlNode(XmlDocument xDoc,string xPath, string sValue)
        {
            XmlNode nodeControl = xDoc.SelectSingleNode(xPath);
            nodeControl.Attributes["Value"].Value = sValue;
            return xDoc;
        }


        #region Connect SQL SERVER
        public DataTable Retreive(string sql, string Connection)
        {
            #region Code
            try
            {
                SqlConnection conn = new SqlConnection(Connection);

                if (conn.State == System.Data.ConnectionState.Open) conn.Close();
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "DATA");
                conn.Close();
                conn.Dispose();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorLog = ex.Message;
                return null;
            }
            #endregion
        }
        public bool Execute(string[] sql, string Connection)
        {
            #region Code
            SqlTransaction transaction = null;
            try
            {
                SqlConnection conn = new SqlConnection(Connection);
                if (conn.State == System.Data.ConnectionState.Open) conn.Close();
                conn.Open();
                transaction = conn.BeginTransaction();
                for (int il = 0; il < sql.Length; il++)
                {
                    new SqlCommand(sql[il], conn, transaction).ExecuteNonQuery();
                }
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                ErrorLog = ex.Message;
                if (transaction != null) transaction.Rollback();
                return false;
            }
            #endregion
        }
        public bool Execute(string sql, string Connection)
        {
            #region Code
            try
            {
                SqlConnection conn = new SqlConnection(Connection);
                if (conn.State == System.Data.ConnectionState.Open) conn.Close();
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.CommandText = sql;
                comm.CommandType = System.Data.CommandType.Text;
                comm.Connection = conn;
                comm.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                ErrorLog = ex.Message;
                return false;
            }
            #endregion
        }
        private string LastQuery = "";
        string ErrorLog;
        public string _ErrorLog
        {
            set { ErrorLog = value; }
            get { return ErrorLog; }
        }
        public bool Execute(string SQL, string Parameter, string img, string Connection)
        {
            if (img != null)
            {
                try
                {
                    SqlConnection conn = new SqlConnection(Connection);
                    if (conn.State == System.Data.ConnectionState.Open) conn.Close();
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL, conn);
                    SqlParameter pic = new SqlParameter(Parameter, SqlDbType.Text);
                    pic.Value = img;
                    cmd.Parameters.Add(pic);
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 250;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    ErrorLog = ex.Message;
                    return false;
                }
            }
            else
            {
                ErrorLog = "ไม่พบข้อมูล Byte[] ที่ส่งมา";
                return false;
            }
        }
        #endregion

        #region DataEncrypterDecrypter
        public string Encrypt(string input)
        {

            String Key = Configuration["WorkSpaceConfig:EncryptKey"];

            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(Configuration["WorkSpaceConfig:EncryptKey"]);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public string Decrypt(string input)
        {
            byte[] inputArray = Convert.FromBase64String(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(Configuration["WorkSpaceConfig:EncryptKey"]);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        #endregion
    }
}