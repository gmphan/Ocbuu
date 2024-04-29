using Microsoft.AspNetCore.Mvc;
using Ocbuu.DataAcess.Repository.IRepository;
using Ocbuu.Models;
using Ocbuu.Models.ViewModels;
using System.Diagnostics;

namespace OcbuuCore.Areas.Visitor.Controllers
{
    [Area("Visitor")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnityOfWork _unityOfWork;
        public HomeController(ILogger<HomeController> logger, IUnityOfWork unityOfWork)
        {
            _logger = logger;
            _unityOfWork = unityOfWork;
        }

        public IActionResult Index()
        {
            // getting the latest record based on primary key becuase
            // I only want to send one header back to ResumeVM
            ResumeHeader? resumeHeader = _unityOfWork.ResumeHeader.GetLatestRecord(x => x.Id);
            ResumeSummary? resumeSummary = _unityOfWork.ResumeSummary.GetLatestRecord(x => x.Id);
            IEnumerable<ResumeExperience>? resumeExperiences = _unityOfWork.ResumeExperience.GetAll();
            ResumeVM resumeVM;
            if (resumeHeader != null)
            {
                resumeVM = new()
                {
                    ResumeHeader = resumeHeader,
                    ResumeExperiences = resumeExperiences.OrderByDescending(x => x.EndYear),
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

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
