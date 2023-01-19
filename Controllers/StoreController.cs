using ProiectFinalASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace ProiectFinalASP.Controllers
{
    public class StoreController : Controller
    {
        public ActionResult Index()
        {
            using (ItemContext idb = new ItemContext())
            {/*
                Item i = new Item();

                i.Name = "Sunset Tee";
                i.ImageUrl = "Tshirt1.png";
                i.Price = 30;
                i.Type = "T-Shirt";

                idb.Items.Add(i);
                idb.SaveChanges();*/

                var model = idb.Items.ToList();
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Confirm()
        {
            using (var db = new ItemContext())
            {
                db.Carts.RemoveRange(db.Carts);
                db.SaveChanges();
            }

            return Json("Confirmed Purchase");
        }
    }
    
}