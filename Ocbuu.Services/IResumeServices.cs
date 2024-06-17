using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocbuu.Models;

namespace Ocbuu.Services
{
    public interface IResumeServices
    {
        public Task<ResumeHeader> GetLatestResumeHeaderAsync();
        public Task<ResumeSummary> GetLatestResumeSummaryAsync();
        public Task<List<ResumeExperience>> GetLatestResumeExperienceAsync();
    }
}