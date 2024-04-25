using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Ocbuu.DataAcess;
using Ocbuu.DataAcess.Repository;
using Ocbuu.DataAcess.Repository.IRepository;
using Ocbuu.Models;

namespace OcbuuCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ResumeHeaderController : Controller
    {
        private readonly ILogger<ResumeHeaderController> _logger;
        private readonly IUnityOfWork _unityOfWork;

        public ResumeHeaderController(ILogger<ResumeHeaderController> logger, IUnityOfWork unityOfWork)
        {
            _logger = logger;
            _unityOfWork = unityOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ResumeHeader obj)
        {
            //this check to see if obj is valid compare to 
            //the conditions that we set on the model like
            //MaxLength, Required, Range, ...
            if(ModelState.IsValid)
            {
                //DateTime have to be UtcNow time for postgres db
                obj.CreatedDate = DateTime.UtcNow;
                obj.ModifiedDate = obj.CreatedDate;
                _unityOfWork.ResumeHeader.Add(obj);

                //I can do one SaveChanges after done with all things that
                //I want to add, delete, edit, ... to my db.
                _unityOfWork.Save();
                TempData["success"] = "Successfully Created";
                //if I have to redirect to an action inside the same controller
                //I only need to give the action, if not, I will have to include
                //controller name, too
                // return RedirectToAction("Index", "Resume", new { area = "Visitor"});
                return RedirectToAction("Index", "Resume");
            }

            //if the obj is not valid then return the same Create view again.
            return View();
        }


        // The 'id' has to match with asp-route-'id' from the view
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            ResumeHeader resumeHeaderFromDb = _unityOfWork.ResumeHeader.Get(u => u.Id == id);
            if(resumeHeaderFromDb == null)
            {
                return NotFound();
            }
            return View(resumeHeaderFromDb);
        }

        /* 
            When we post back to here, it posts the same resumeHeaderFromDb object back
            with modified fields in it. 
         */
        [HttpPost]
        public IActionResult Edit(ResumeHeader obj)
        {
            if(ModelState.IsValid)
            {
                _unityOfWork.ResumeHeader.Update(obj); 
                _unityOfWork.Save();
                TempData["success"] = "Successfully Edited";
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

            ResumeHeader resumeHeaderFromDb = _unityOfWork.ResumeHeader.Get(u => u.Id == id);
            if(resumeHeaderFromDb == null)
            {
                return NotFound();
            }
            return View(resumeHeaderFromDb);
        }

        // since Delete(int id) was declared I have to use different name - DeletePost
        // but I have to use notation to tell this action is Delete, so the view would know
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            ResumeHeader? obj = _unityOfWork.ResumeHeader.Get(u => u.Id == id);
            if(obj == null)
            {
                return NotFound();
            }
            _unityOfWork.ResumeHeader.Remove(obj);
            _unityOfWork.Save();
            TempData["success"] = "Successfully Deleted";
            return RedirectToAction("Index", "Resume");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}