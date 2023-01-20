using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProiectFinalASP.Models;

namespace ProiectFinalASP.Models
{
    public class Cart //Cart class that keeps count of bought items
    {
        [Key]
        public int Id { get; set; }
        public string itemName { get; set; }
        public int itemPrice { get; set; }
        public string itemImageUrl { get; set; }
    }
}