using Microsoft.EntityFrameworkCore;

namespace NetCoreUsingVsCode.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=NGTRDAI197\NGTRDAI197;Database=DBNetCoreUsingVsCode;Trusted_Connection=True;ConnectRetryCount=0");
            }
        }
    }
}