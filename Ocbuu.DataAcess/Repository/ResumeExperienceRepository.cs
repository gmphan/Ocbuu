using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocbuu.DataAcess.Repository.IRepository;
using Ocbuu.Models;

namespace Ocbuu.DataAcess.Repository
{
    public class ResumeExperienceRepository : Repository<ResumeExperience>, IResumeExperienceRepository
    {
        private AzurePgDbContext _db;

        public ResumeExperienceRepository(AzurePgDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ResumeExperience obj)
        {
            _db.ResumeExperiences.Update(obj);
        }
    }
}