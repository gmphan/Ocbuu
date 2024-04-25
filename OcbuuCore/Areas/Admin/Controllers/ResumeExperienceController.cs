using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ocbuu.DataAcess.Repository.IRepository;
using Ocbuu.Models;

namespace OcbuuCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ResumeExperienceController : Controller
    {
        private readonly ILogger<ResumeExperienceController> _logger;
        private readonly IUnityOfWork _unityOfWork;
        public ResumeExperienceController(ILogger<ResumeExperienceController> logger, IUnityOfWork unityOfWork)
        {
            _logger = logger;
            _unityOfWork = unityOfWork;
        }

        
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ResumeExperience obj)
        {
            if(ModelState.IsValid)
            {
                obj.CreatedDate = DateTime.UtcNow;
                obj.ModifiedDate = obj.CreatedDate;
                _unityOfWork.ResumeExperience.Add(obj);
                _unityOfWork.Save();
                TempData["success"] = "Successfully Created New Experience";
                return RedirectToAction("Index", "Resume");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            ResumeExperience resumeExperienceFromDb = _unityOfWork.ResumeExperience.Get(u => u.Id == id);
            if(resumeExperienceFromDb == null)
            {
                return NotFound();
            }

            return View(resumeExperienceFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            ResumeExperience? obj = _unityOfWork.ResumeExperience.Get(u => u.Id == id);
            if(obj == null)
            {
                return NotFound();
            }
            _unityOfWork.ResumeExperience.Remove(obj);
            _unityOfWork.Save();
            TempData["success"] = "Successfully Deleted";
            return RedirectToAction("Index", "Resume");
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            ResumeExperience resumeExperienceFromDb = _unityOfWork.ResumeExperience.Get(u=>u.Id == id);
            if(resumeExperienceFromDb == null)
            {
                return NotFound();
            }

            return View(resumeExperienceFromDb);

        }

        [HttpPost]
        public IActionResult Edit(ResumeExperience obj)
        {
            if(ModelState.IsValid)
            {
                _unityOfWork.ResumeExperience.Update(obj);
                _unityOfWork.Save();
                TempData["success"] = "Successfully Edited";
                return RedirectToAction("Index", "Resume");
            }
            return View();
        }
    }
}