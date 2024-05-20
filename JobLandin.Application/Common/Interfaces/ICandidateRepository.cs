using System.Linq.Expressions;
using JobLandin.Domain.Entities;

namespace JobLandin.Application.Common.Interfaces;

public interface ICandidateRepository : IRepository<Candidate>
{
    void Update(Candidate entity);
    Task<Candidate> GetFirstOrDefaultAsync(Expression<Func<Candidate, bool>> filter = null);
}