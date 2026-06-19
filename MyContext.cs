using Demo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Contexts
{
    public class MyContext : DbContext
    {
        String connectionString = "Server=WIN-C4UM3B4G5HP; Trusted_Connection=True;" + "Database=demo; TrustServerCertificate=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Partner> partner { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<Sale> sale { get; set; }
    }
}
