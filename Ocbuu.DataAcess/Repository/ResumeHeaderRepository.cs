using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ocbuu.DataAcess.Repository.IRepository;
using Ocbuu.Models;

namespace Ocbuu.DataAcess.Repository
{
    public class ResumeHeaderRepository : Repository<ResumeHeader>, IResumeHeaderRepository
    {
        private AzurePgDbContext _db;

        //the base(db) is to pass the db to the base classes - Repository, or
        //else I will get error message the line 11 public class
        public ResumeHeaderRepository(AzurePgDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ResumeHeader obj)
        {
            _db.ResumeHeaders.Update(obj);
        }
    }
}