using JobLandin.Domain.Entities;
using System.Linq.Expressions;

namespace JobLandin.Application.Common.Interfaces
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAll(Expression<Func>);
    }
}
