using ProiectFinalASP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace ProiectFinalASP.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddToCart(int id)
        {
            if (id == 0)
            {
                using (ItemContext idb = new ItemContext())
                {
                    return View(idb.Carts.ToList());
                }
            }
            else
                using (ItemContext idb = new ItemContext())
                {
                    Item item = idb.Items.Find(id);
                    Cart c = new Cart();

                    c.itemName = item.Name;
                    c.itemPrice = item.Price;
                    c.itemImageUrl = item.ImageUrl;

                    idb.Carts.Add(c);
                    idb.SaveChanges();

                    return View(idb.Carts.ToList());
                }
        }

        public ActionResult Account()
        {
            return View();
        }

        public ActionResult Account2()
        {
            return View();
        }
        //Criptarea datelor - contributia lui Joldes
        static RijndaelManaged rijndael = new RijndaelManaged();
        static byte[] EncryptString(string plainText)
        {
            byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            using (MemoryStream ms = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(ms, rijndael.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(plainTextBytes, 0, plainTextBytes.Length);
                cs.FlushFinalBlock();
                byte[] cipherTextBytes = ms.ToArray();
                return cipherTextBytes;
            }
        }
        //Criptarea datelor - contributia lui Joldes

        [HttpPost]
        public ActionResult AccountCheck(string name, string password)
        {
            using (ItemContext idb = new ItemContext())
            {
                foreach (var user in idb.Users)
                {
                    //Criptarea datelor - contributia lui Joldes
                    rijndael.KeySize = 256;
                    rijndael.BlockSize = 256;
                    rijndael.GenerateKey();
                    rijndael.GenerateIV();
                    //Criptarea datelor - contributia lui Joldes

                    //Validarea datelor de intrare in AccountCheck - contributia lui Joldes
                    if (name.Length < 3)
                    {
                        return Json("Username has too few characters");
                    }
                    else if (password.Length < 3)
                    {
                        return Json("Password has too few characters");
                    }
                    else if(name.Length < 3 && password.Length < 3)
                    {
                        return Json("Error logging, username and password have too few characters");
                    }
                    //Validarea datelor de intrare in AccountCreate - contributia lui Joldes

                    if (user.Username == name && user.Password == password)
                    {
                        //Criptarea datelor - contributia lui Joldes
                        byte[] encryptPassword = EncryptString(password);
                        Credentials.LoggedinPassword = encryptPassword;
                        Credentials.LoggedinUsername = name;
                        //Criptarea datelor - contributia lui Joldes
                        Credentials.IsLoggedIn= true;
                        return Json("Succesfully logged in");
                    }
                }
            }
            return Json("Wrong username or password");
        }

        [HttpPost]
        public ActionResult AccountCreate(string name, string password)
        {
            using (ItemContext idb = new ItemContext())
            {
                //Validarea datelor de intrare in AccountCreate - contributia lui Joldes
                if (name.Length >= 3 && password.Length >= 3)
                {
                    return Json("User was registered");
                }
                else if (name.Length < 3)
                {
                    return Json("Username has too few characters");
                }
                else if (password.Length < 3)
                {
                    return Json("Password has too few characters");
                }
                else if (name.Length < 3 && password.Length < 3)
                {
                    return Json("Error registering, username and password have too few characters");
                }
                //Validarea datelor de intrare in AccountCreate - contributia lui Joldes

                foreach (var user in idb.Users)
                {
                    if (user.Username == name)
                        return Json("Username is taken");
                }

                User u = new User();
                u.Username = name;
                u.Password = password;

                idb.Users.Add(u);
                idb.SaveChanges();
            }
            return Json("Account succesfully created");
        }
    }
}