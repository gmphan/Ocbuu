using Microsoft.AspNetCore.Mvc;
using Ocbuu.DataAcess;
using Ocbuu.DataAcess.Repository.IRepository;
using Ocbuu.Models;
using Ocbuu.Models.ViewModels;



namespace OcbuuCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ResumeController : Controller
    {
        private readonly ILogger? _logger;
        private readonly IUnityOfWork _unityOfWork;
        public ResumeController(ILogger<ResumeController> logger, IUnityOfWork unityOfWork)
        {
            _logger = logger;
            _unityOfWork = unityOfWork;
        }

        public IActionResult Index()
        {
             //List<ResumeHeader> objResumeHeaderList = _db.ResumeHeaders.ToList();
            
            // getting the latest record based on primary key becuase
            // I only want to send one header back to ResumeVM
            ResumeHeader? resumeHeader = _unityOfWork.ResumeHeader.GetLatestRecord(x => x.Id);
            IEnumerable<ResumeExperience>? resumeExperiences = _unityOfWork.ResumeExperience.GetAll();
            ResumeSummary? resumeSummary = _unityOfWork.ResumeSummary.GetLatestRecord(x => x.Id);

            ResumeVM resumeVM;
            if (resumeHeader != null)
            {
                resumeVM = new()
                {
                    ResumeHeader = resumeHeader,
                    ResumeExperiences = resumeExperiences,
                    ResumeSummary = resumeSummary
                };
            }
            else
            {
                //I should think of something here if there is not header then what I should do
                //for now I will just take it to the header create view
                ViewBag.ErrorMessage = "No ResumeHeader was found.";
                // return View("Error");
                TempData["warning"] = "Need to create a Resume Header";
                return RedirectToAction("Create", "ResumeHeader", new { area = "Admin"});
            }
            return View(resumeVM);
        }

        public IActionResult Create() {
            return View();
        }
    }
}
