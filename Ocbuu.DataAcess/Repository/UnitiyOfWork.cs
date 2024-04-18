using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocbuu.DataAcess.Repository.IRepository;

namespace Ocbuu.DataAcess.Repository
{
    public class UnitiyOfWork : IUnityOfWork
    {
        private AzurePgDbContext _db;
        public IResumeHeaderRepository ResumeHeader { get; private set; }

        public IResumeExperienceRepository ResumeExperience { get; private set; }
        public IResumeSummaryRepository ResumeSummary { get; private set; }

        public UnitiyOfWork(AzurePgDbContext db)
        {
            _db = db;
            ResumeHeader = new ResumeHeaderRepository(_db);
            ResumeExperience = new ResumeExperienceRepository(_db);
            ResumeSummary = new ResumeSummaryRepository(_db);
        }
        

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}