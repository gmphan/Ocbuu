using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocbuu.Models;

namespace Ocbuu.DataAcess.Repository.IRepository
{
    public interface IResumeSummaryRepository : IRepository<ResumeSummary>
    {
        void Update(ResumeSummary obj);        
    }
}