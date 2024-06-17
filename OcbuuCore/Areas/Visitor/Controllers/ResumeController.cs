using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ocbuu.DataAcess.Repository.IRepository;
using Ocbuu.Models;
using Ocbuu.Models.ViewModels;
using Ocbuu.Services;

namespace OcbuuCore.Areas.Visitor.Controllers
{
    [Area("Visitor")]
    public class ResumeController : Controller
    {
        private readonly ILogger<ResumeController> _logger;
        private readonly IResumeServices _resumeServices;

        public ResumeController(ILogger<ResumeController> logger
                               , IResumeServices resumeServices)
        {
            _logger = logger;
            _resumeServices = resumeServices;
            
        }

        public async Task<IActionResult> Index()
        {
            ResumeView resumeView = new ResumeView();
            await _resumeServices.GetLatestResumeHeaderAsync();
            return View(resumeView);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}