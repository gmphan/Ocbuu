using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ocbuu.DataAcess.Repository.IRepository;
using Ocbuu.Models;

namespace OcbuuCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ResumeSummaryController : Controller
    {
        private readonly ILogger<ResumeSummaryController> _logger;
        private readonly IUnityOfWork _UnityOfWork;

        public ResumeSummaryController(ILogger<ResumeSummaryController> logger, 
                                        IUnityOfWork unityOfWork)
        {
            _logger = logger;
            _UnityOfWork = unityOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ResumeSummary resumeSummary = _UnityOfWork.ResumeSummary.Get(u => u.Id == id);
            if(resumeSummary == null)
            {
                return NotFound();
            }
            return View(resumeSummary);
        }

        [HttpPost]
        public IActionResult Edit(ResumeSummary obj)
        {
            if(ModelState.IsValid)
            {
                _UnityOfWork.ResumeSummary.Update(obj);
                _UnityOfWork.Save();
                TempData["success"] = "Successfully Edited";
            }
            return RedirectToAction("Index", "Resume");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}