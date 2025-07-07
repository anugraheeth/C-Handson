using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JobPortal.Domain;

namespace JobPortal.Infrastructure.DBContext
{
    internal class JobPortalContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=Anugraheeths_PC\\SQLEXPRESS;Initial Catalog=TesteJobPortal;Integrated Security=True;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seed data
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = "00001",
                    EmployeeName = "Anugraheeth",
                    EmployeeEmail = "test@email.com",
                    EmployeePhone = "1234567890",
                    Organization = "Test"
                });
        }
    }
}
