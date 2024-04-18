using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ocbuu.DataAcess.Repository.IRepository
{
    public interface IUnityOfWork
    {
        IResumeHeaderRepository ResumeHeader { get; }
        IResumeExperienceRepository ResumeExperience { get; }
        IResumeSummaryRepository ResumeSummary { get; }
        void Save();
    }
}