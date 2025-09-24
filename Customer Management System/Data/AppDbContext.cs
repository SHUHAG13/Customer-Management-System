using Customer_Management_System.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Customer_Management_System.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        
        public DbSet<Customer> Customers { get; set; }
    }
}
