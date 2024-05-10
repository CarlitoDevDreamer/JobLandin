using JobLandin.Application.Common.Interfaces;
using JobLandin.Domain.Entities;
using JobLandin.Infrastructure.Data;

namespace JobLandin.Infrastructure.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
       
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Company entity)
        {
            _db.Update(entity);
        }
    }
}
