using JobLandin.Domain.Entities;
using System.Linq.Expressions;

namespace JobLandin.Application.Common.Interfaces
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAll(Expression<Func<Company, bool>>? filter = null, string? includeProperties = null);
        IEnumerable<Company> Get(Expression<Func<Company, bool>> filter, string? includeProperties = null);
        void Add(Company entity);
        void Update(Company entity);
        void Remove(Company entity);
        void Save();
    }
}
