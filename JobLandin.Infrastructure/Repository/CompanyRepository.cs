using JobLandin.Application.Common.Interfaces;
using JobLandin.Domain.Entities;
using JobLandin.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JobLandin.Infrastructure.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(Company entity)
        {
            _db.Add(entity);
        }

        public Company Get(Expression<Func<Company, bool>> filter, string? includeProperties = null)
        {
            IQueryable<Company> query = _db.Set<Company>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeprop in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperties);
                }
            }
            return query.FirstOrDefault()!;
        }

        public IEnumerable<Company> GetAll(Expression<Func<Company, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<Company> query = _db.Set<Company>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach(var includeprop in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) 
                {
                query = query.Include(includeProperties);
                }
            }
            return query.ToList();
        }

        public void Remove(Company entity)
        {
            _db.Remove(entity);
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
