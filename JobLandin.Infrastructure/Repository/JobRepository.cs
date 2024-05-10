using JobLandin.Application.Common.Interfaces;
using JobLandin.Domain.Entities;
using JobLandin.Infrastructure.Data;

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
    }
}
