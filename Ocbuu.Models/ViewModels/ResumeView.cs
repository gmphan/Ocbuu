using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ocbuu.Models.ViewModels
{
    public class ResumeView
    {
        // A Header
        public ResumeHeader? ResumeHeader { get; set; }
        // A Summary
        public ResumeSummary? ResumeSummary { get; set; }
        // A Experience list
        public List<ResumeExperience>? ResumeExperiences { get; set; }

        public ResumeView()
        {
            ResumeHeader = new ResumeHeader();
            ResumeSummary = new ResumeSummary();
            ResumeExperiences = new List<ResumeExperience>();
        }

        public void AddExperience(ResumeExperience experience)
        {
            ResumeExperiences.Add(experience);
        }

        public void SortByExperienceDate()
        {
            if (ResumeExperiences.Count > 0)
            {
                ResumeExperiences = ResumeExperiences.OrderByDescending(x => x.EndYear).ToList(); 
            }
        }
    }
}