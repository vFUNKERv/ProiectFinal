using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProiectFinalASP.Controllers
{
    public class HomeController : Controller
    {
        //Simple method that shows the index webpage
        public ActionResult Index()
        {
            return View();
        }

        //Simple method that shows the About webpage
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //Simple method that shows the Contact webpage
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}