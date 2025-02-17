using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebManagement.Models;

namespace WebManagement.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IHostingEnvironment hostingEnvironment, IConfiguration configuration, IHttpContextAccessor ihttpContextAccessor)
        {
            IhttpContextAccessor = ihttpContextAccessor;
            Configuration = configuration;
            var ApiUrl = Environment.GetEnvironmentVariable("serverUrl");
            Configuration["APIService:url"] = ApiUrl;
            ManagementController mc = new ManagementController(hostingEnvironment, configuration, ihttpContextAccessor);
            mc.ControllerContext = ControllerContext;
            mc.LoadMenu();
        }
        public IConfiguration Configuration { get; }
        public IHttpContextAccessor IhttpContextAccessor { get; }
        public IActionResult Index()
        {
            return View();
        }
 
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
