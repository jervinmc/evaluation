using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using evaluation.Models; // Make sure to add the correct namespace for your models

namespace evaluation.Data // Update with your actual namespace
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSet properties for your entity models
        public DbSet<User> Users { get; set; }
        // Add more DbSet properties as needed
    }
}
