using JobLandin.Domain.Entities;
using System.Linq.Expressions;

namespace JobLandin.Application.Common.Interfaces
{
    public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company entity);
        
    }
}
