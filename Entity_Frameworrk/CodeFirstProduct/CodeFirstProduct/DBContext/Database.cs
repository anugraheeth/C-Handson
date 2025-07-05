using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using CodeFirstProduct.Entities;

namespace CodeFirstProduct.DBContext
{
    internal class Database : DbContext
    {
        //manage connections
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //set the connection string
            optionsBuilder.UseSqlServer("Data Source=Anugraheeths_PC\\SQLEXPRESS;Initial Catalog=EProduct;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

        }

        //define the dbset for the Product entity to represent the Products table in the database

        //entity sets are used to query and save instances of entities
        public DbSet<Product> Products { get; set; } // This property represents the Products table in the database
    }
}

