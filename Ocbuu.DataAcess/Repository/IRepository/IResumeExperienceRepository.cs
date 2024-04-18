using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocbuu.Models;

namespace Ocbuu.DataAcess.Repository.IRepository
{
    public interface IResumeExperienceRepository : IRepository<ResumeExperience>
    {
        void Update(ResumeExperience obj);
    }
}