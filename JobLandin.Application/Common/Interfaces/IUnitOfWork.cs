using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobLandin.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        ICompanyRepository Company { get; }
        void Save();
    }
}
