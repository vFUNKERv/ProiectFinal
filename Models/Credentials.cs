using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProiectFinalASP.Models
{
    public static class Credentials //Static credential class, stores user info
    {
        public static string LoggedinUsername { get; set; }
        public static byte[] LoggedinPassword { get; set; }
        public static bool IsLoggedIn { get; set; }
    }
}