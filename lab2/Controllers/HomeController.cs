using lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace lab2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Results(FormModel model)
        {
            int Year = model.Date.Year;
            if (((Year % 4 == 0) && (Year % 100 != 0)) || (Year % 400 == 0))
                model.LeapYear = true;
            else
                model.LeapYear = false;

            DateTime a = model.Date;
            DateTime b = DateTime.Now;
            TimeSpan duration = b - a;

            model.DaysSinceBirth = duration.Days;
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
