using System.Linq.Expressions;
using JobLandin.Application.Common.Interfaces;
using JobLandin.Domain.Entities;
using JobLandin.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace JobLandin.Infrastructure.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<Company> _dbSet;

        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
            _dbSet = _db.Set<Company>();
        }


        public void Update(Company entity)
        {
            _db.Update(entity);
        }

        public async Task<Company> GetFirstOrDefaultAsync(Expression<Func<Company, bool>> filter = null)
        {
            IQueryable<Company> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.FirstOrDefaultAsync();
        }
    }
}
