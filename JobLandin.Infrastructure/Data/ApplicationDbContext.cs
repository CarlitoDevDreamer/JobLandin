using JobLandin.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobLandin.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Job>().HasData(new Job
            {
                Id = 1,
                Title = "Software Developer",
                Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                Location = "Lagos",
                Salary = 2000,
            },
            new Job
            {
                Id = 2,
                Title = "Data Analyst",
                Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                Location = "Abuja",
                Salary = 1500,
            },
            new Job
            {
                Id = 3,
                Title = "Product Manager",
                Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                Location = "Port Harcourt",
                Salary = 2500,
            }
            );
        }
    }
}
