using System.Diagnostics;
using Lab7.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab7.Controllers
{
    public class NnhHomeController : Controller
    {
        private readonly ILogger<NnhHomeController> _logger;

        public NnhHomeController(ILogger<NnhHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult NnhIndex()
        {
            return View();
        }

        public IActionResult NnhAbout()
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
