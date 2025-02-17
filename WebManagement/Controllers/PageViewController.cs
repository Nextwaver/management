using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebManagement.Controllers
{
    public class PageViewController : Controller
    {
        public IActionResult RedirecToPageView(String Path)
        {
            String[] spPath = Path.Split('/');
            String ControllerName = spPath[0];
            String ActionName = spPath[1];
            return RedirectToAction(ActionName, ControllerName);
        }
        public IActionResult PV_Empty()
        {
            return View();
        }
    }
}