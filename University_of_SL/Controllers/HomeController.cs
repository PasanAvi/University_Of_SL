using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using University_of_SL.Models;
using Microsoft.EntityFrameworkCore;
using University_of_SL.Data;

namespace University_of_SL.Controllers
{
    public class HomeController : Controller
    {
        private readonly SchoolContext _context;

        public HomeController(SchoolContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> About()
        {
            IQueryable<EnrollementDates> data = from Student in _context.Students
                                                group Student by Student.EnrollmentDate into
                                                dategroup
                                                select new EnrollementDates()
                                                {
                                                    EnrollementDate = dategroup.Key,
                                                    Studentcount = dategroup.Count()
                                                };
            return View(await data.AsNoTracking().ToListAsync());
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
