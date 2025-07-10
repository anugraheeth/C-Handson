using TaskItem.Models;
using Microsoft.EntityFrameworkCore;
namespace TaskItem.Models
{
    public class DBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=Anugraheeths_PC\\SQLEXPRESS;Initial Catalog=TaskItemDB;Integrated Security=True;TrustServerCertificate=True");
        }
        public DbSet<TaskItems> TaskItems { get; set; }
    }
}
