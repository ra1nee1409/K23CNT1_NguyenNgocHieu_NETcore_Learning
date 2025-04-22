using Microsoft.AspNetCore.Mvc;

namespace Day1._2.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
