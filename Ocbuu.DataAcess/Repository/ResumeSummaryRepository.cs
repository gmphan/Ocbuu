using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ocbuu.DataAcess.Repository.IRepository;
using Ocbuu.Models;

namespace Ocbuu.DataAcess.Repository
{
    public class ResumeSummaryRepository : Repository<ResumeSummary>, IResumeSummaryRepository
    {
        private AzurePgDbContext _db;
        public ResumeSummaryRepository(AzurePgDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(ResumeSummary obj)
        {
            _db.ResumeSummaries.Update(obj);
        }

    }
}