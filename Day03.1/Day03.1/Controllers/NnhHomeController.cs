using System.Diagnostics;
using Day03._1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day03._1.Controllers
{
    public class NnhHomeController : Controller
    {
        private readonly ILogger<NnhHomeController> _logger;

        public NnhHomeController(ILogger<NnhHomeController> logger)
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
