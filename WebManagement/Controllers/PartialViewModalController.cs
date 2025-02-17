using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebManagement.Models;

namespace WebManagement.Controllers
{
    public class PartialViewModalController : Controller
    {
        NextwaverDB.NColumns NCS_S = new NextwaverDB.NColumns();
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult PVM_User()
        {
            return PartialView();
        }
        public ActionResult PVM_Position()
        {
            return PartialView();
        }
        public ActionResult PVM_Book()
        {
            return PartialView();
        }
        public ActionResult PVM_Page()
        {
            return PartialView();
        }
    }
}