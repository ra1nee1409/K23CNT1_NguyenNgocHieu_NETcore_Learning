using Day6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day6.Controllers
{
    public class NnhEmployeeController : Controller
    {
        public static List<NnhEmployee> nnhListEmployee = new List<NnhEmployee>()
    {
        new NnhEmployee { NnhId = 1, NnhName = "Nguyễn Văn A", NnhBirthDay = new DateTime(2000,1,1), NnhEmail = "a1@example.com", NnhPhone = "0123456789", NnhSalary = 551000, NnhStatus = true },
        new NnhEmployee { NnhId = 2, NnhName = "Nguyễn Ngọc Hiếu", NnhBirthDay = new DateTime(2005,9,14), NnhEmail = "a22@example.com", NnhPhone = "0123456789", NnhSalary = 527000, NnhStatus = true },
        new NnhEmployee { NnhId = 3, NnhName = "Lê Ngọc Sơn", NnhBirthDay = new DateTime(2004,3,3), NnhEmail = "a333@example.com", NnhPhone = "0123456789", NnhSalary = 538000, NnhStatus = true },
        new NnhEmployee { NnhId = 4, NnhName = "Trần Tiến Anh", NnhBirthDay = new DateTime(2005,12,12), NnhEmail = "a4444@example.com", NnhPhone = "0123456789", NnhSalary = 596000, NnhStatus = true },
        new NnhEmployee { NnhId = 5, NnhName = "Nguyễn Hoài Nam", NnhBirthDay = new DateTime(2001,1,12), NnhEmail = "a55555@example.com", NnhPhone = "0123456789", NnhSalary = 512000, NnhStatus = true },
        new NnhEmployee { NnhId = 6, NnhName = "Nguyễn Quang Tâm", NnhBirthDay = new DateTime(2012,3,5), NnhEmail = "a666666@example.com", NnhPhone = "0123456789", NnhSalary = 533000, NnhStatus = true }

    };

        public IActionResult NnhIndex()
        {
            return View(nnhListEmployee);
        }

        [HttpGet]
        public IActionResult NnhCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NnhCreateSubmit(NnhEmployee emp)
        {
            emp.NnhId = nnhListEmployee.Max(e => e.NnhId) + 1;
            nnhListEmployee.Add(emp);
            return RedirectToAction("NnhIndex");
        }
    }

}
