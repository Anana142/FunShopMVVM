using FunShopMVVMTwo.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunShopMVVMTwo.Tools
{
    public class DboContext : DbContext
    {
        private string filePath;

        public DboContext(string filePath)
        {
            this.filePath = filePath;
        }

        public string Role { get; set; }
        public DbSet<User> Users { get; set; }  
        public DbSet<Product> Products { get; set; }    
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"FileName={filePath}"); 
            base.OnConfiguring(optionsBuilder);
        }
    }
}
