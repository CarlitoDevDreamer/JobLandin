using System.Linq.Expressions;
using JobLandin.Application.Common.Interfaces;
using JobLandin.Domain.Entities;
using JobLandin.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace JobLandin.Infrastructure.Repository
{
    public class CandidateRepository : Repository<Candidate>, ICandidateRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<Candidate> _dbSet;

        public CandidateRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
            _dbSet = _db.Set<Candidate>();
        }


        public void Update(Candidate entity)
        {
            _db.Update(entity);
        }

        public async Task<Candidate> GetFirstOrDefaultAsync(Expression<Func<Candidate, bool>> filter = null)
        {
            IQueryable<Candidate> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.FirstOrDefaultAsync();
        }
    }
}