using JobLandin.Application.Common.Interfaces;
using JobLandin.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobLandin.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _db;
        public ICompanyRepository Company { get; private set; }
        public IJobRepository Job { get; private set; }
        
        public ICandidateRepository Candidate { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Company = new CompanyRepository(db);
            Job = new JobRepository(db);
            Candidate = new CandidateRepository(db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
