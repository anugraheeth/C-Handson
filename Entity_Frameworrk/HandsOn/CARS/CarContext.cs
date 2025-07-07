using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace CARS
{
    public class CarContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=Anugraheeths_PC\\SQLEXPRESS;initial catalog=CARS;integrated security=True;TrustServerCertificate=True");
        }
        public DbSet<Cars> Cars { get; set; }
    }
}
