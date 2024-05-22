using JobLandin.Domain.Entities;

namespace JobLandin.Application.Common.Interfaces
{
    public interface IJobRepository : IRepository<Job>
    {
        void Update(Job entity);
        IEnumerable<Job> SearchJobs(string searchString);
    }

}
