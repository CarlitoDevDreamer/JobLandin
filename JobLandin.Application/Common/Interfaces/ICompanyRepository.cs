using JobLandin.Domain.Entities;
using System.Linq.Expressions;

namespace JobLandin.Application.Common.Interfaces
{
    public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company entity);
        Task<Company> GetFirstOrDefaultAsync(Expression<Func<Company, bool>> filter = null);
    }
}
