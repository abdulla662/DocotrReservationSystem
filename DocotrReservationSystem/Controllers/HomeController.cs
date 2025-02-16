using DocotrReservationSystem.DataAcess;
using DocotrReservationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DocotrReservationSystem.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext dbContext=new ApplicationDbContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult BookAppointment(int doctorid ) {
            var data = dbContext.Doctors.ToList();
            if (data != null) {
                return View(data);
            }
            return RedirectToAction(nameof(NotFoundPage));


        }
        public IActionResult CompleteAppointment(int doctorId)
        {
            var data = dbContext.Doctors.FirstOrDefault(e => e.Id == doctorId);
            if (data != null)
            {
                return View(data);
            }
            return RedirectToAction(nameof(NotFoundPage));
        }


        public IActionResult ReservationsManagement() {
            return View();

        }
        public IActionResult NotFoundPage() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
