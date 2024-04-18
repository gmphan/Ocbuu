using Ocbuu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocbuu.Models.ViewModels
{
    public class ResumeVM
    {
        public ResumeHeader? ResumeHeader { get; set; }
        public IEnumerable<ResumeExperience>? ResumeExperiences { get; set; }
        public ResumeSummary? ResumeSummary { get; set; }

    }
}
