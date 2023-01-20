using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProiectFinalASP.Models;

namespace ProiectFinalASP.Models
{
    public class Item //Item class with relevant field
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public string Type { get; set; }
        public int Price { get; set; }
    }

    public class ItemContext : DbContext // Create db context, and the Items, Carts, and Users tables
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}