using JobLandin.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace JobLandin.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Company>().HasData(new Company

            {
                CompanyId = 1,
                CompanyName = "Google",
                Location = "Lagos",
                Industry = "Technology",
                Size = 1000,
                Description = "Google is a multinational technology company that specializes in Internet-related services and products, which include online advertising technologies, a search engine, cloud computing, software, and hardware.",
                Website = "https://www.google.com",
                LogoUrl = "https://placehold.co/600x400",



            }, 
            new Company
            {
                CompanyId = 2,
                CompanyName = "Facebook",
                Location = "Abuja",
                Industry = "Technology",
                Size = 500,
                Description = "Facebook is an American online social media and social networking service company based in Menlo Park, California.",
                Website = "https://www.facebook.com",
                LogoUrl = "https://placehold.co/600x400",
            }, 
            new Company
            {
                CompanyId = 3,
                CompanyName = "Microsoft",
                Location = "Port Harcourt",
                Industry = "Technology",
                Size = 2000,
                Description = "Microsoft Corporation is an American multinational technology company with headquarters in Redmond, Washington.",
                Website = "https://www.microsoft.com",
                LogoUrl = "https://placehold.co/600x400",

            }

                );









            modelBuilder.Entity<Job>().HasData(new Job
            {
                Id = 1,
                CompanyId = 1,
                Title = "Software Developer",
                Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                Location = "Lagos",
                Salary = 2000,
                ApplicationMethod = ApplicationType.Link,
                ApplicationDetails = "https://www.google.com/careers/",
                CreatedAt = DateTime.Now,
            },
            new Job
            {
                Id = 2,
                CompanyId = 3,
                Title = "Data Analyst",
                Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                Location = "Abuja",
                Salary = 1500,
                ApplicationMethod = ApplicationType.Email,
                ApplicationDetails = "data@email.com",
                CreatedAt = DateTime.Now,
            },
            new Job
            {
                Id = 3,
                CompanyId = 2,
                Title = "Product Manager",
                Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                Location = "Port Harcourt",
                Salary = 2500,
                ApplicationMethod = ApplicationType.Phone,
                ApplicationDetails = "08012345678",
                CreatedAt = DateTime.Now,
            }
            );










        }
    }
}
