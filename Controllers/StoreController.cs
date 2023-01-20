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
        public ActionResult Index() // Store index view method that shows all available products
        {
            using (ItemContext idb = new ItemContext())
            {
                /*
                Item i = new Item();            //code used to add new items at runtime

                i.Name = "Wing Trousers";
                i.ImageUrl = "Pants2.png";
                i.Price = 999;
                i.Type = "Pants";

                idb.Items.Add(i);
                idb.SaveChanges();*/

                var model = idb.Items.ToList(); //Converts all items to a list
                return View(model); //sends list of items to store index view
            }
        }

        [HttpPost]//Code for when a cart purchase is succesful
        public ActionResult Confirm()
        {
            using (var db = new ItemContext())
            {
                db.Database.ExecuteSqlCommand("DELETE FROM Carts");
                //db.SaveChanges();
            }

            return Json("Confirmed Purchase");
        }
    }
    
}