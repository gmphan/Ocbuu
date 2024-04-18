using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OcbuuCore.Areas.Admin.Controllers
{
    [Route("[controller]")]
    public class ResumeSummaryController : Controller
    {
        private readonly ILogger<ResumeSummaryController> _logger;

        public ResumeSummaryController(ILogger<ResumeSummaryController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}