using JobLandin.Application.Common.Interfaces;
using JobLandin.Domain.Entities;
using JobLandin.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace JobLandin.Infrastructure.Repository
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        private readonly ApplicationDbContext _db;

        public JobRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
       


        public void Update(Job entity)
        {
            _db.Update(entity);
        }

        public IEnumerable<Job> SearchJobs(string searchString)
        {
            return _db.Set<Job>()
                .Include(j => j.Company) // Include the related Company data
                .Where(j => j.Title.Contains(searchString) || j.Description.Contains(searchString))
                .ToList();
        }
    }
}
