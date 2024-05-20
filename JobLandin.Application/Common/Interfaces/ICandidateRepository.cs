using System.Linq.Expressions;
using JobLandin.Domain.Entities;

namespace JobLandin.Application.Common.Interfaces;

public interface ICandidateRepository : IRepository<Candidate>
{
    void Update(Candidate entity);
    //Task<Company> GetFirstOrDefaultAsync(Expression<Func<Company, bool>> filter = null);
}