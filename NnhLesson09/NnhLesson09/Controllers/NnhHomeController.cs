using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NnhLesson09.Models;

namespace NnhLesson09.Controllers
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

        public IActionResult NnhPrivacy()
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
