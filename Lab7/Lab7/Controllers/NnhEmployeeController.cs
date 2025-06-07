using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lab7.Models;
namespace Lab7.Controllers
{
    public class NnhEmployeeController : Controller
    {
        // Mock Data:
        private static List<NnhEmployee> nnhListEmployee = new List<NnhEmployee>()
        {
            new NnhEmployee
            {
                NnhId = 231090037,
                NnhName = "Nguyen Ngoc Hieu",
                NnhBirthday = new DateTime(2005, 9, 14),
                NnhEmail = "sthieuhoctap@gmail.com",
                NnhPhone = "0966140905",
                NnhSalary = 15000000,
                NnhStatus = true
            },
            new NnhEmployee
            {
                NnhId = 2,
                NnhName = "Tran Thi B",
                NnhBirthday = new DateTime(1992, 8, 20),
                NnhEmail = "b.tran@example.com",
                NnhPhone = "0912345678",
                NnhSalary = 13000000,
                NnhStatus = false
            },
            new NnhEmployee
            {
                NnhId = 3,
                NnhName = "Le Van C",
                NnhBirthday = new DateTime(1988, 3, 15),
                NnhEmail = "c.le@example.com",
                NnhPhone = "0987654321",
                NnhSalary = 17000000,
                NnhStatus = true
            },
            new NnhEmployee
            {
                NnhId = 4,
                NnhName = "Pham Thi D",
                NnhBirthday = new DateTime(1995, 12, 1),
                NnhEmail = "d.pham@example.com",
                NnhPhone = "0978123456",
                NnhSalary = 12000000,
                NnhStatus = true
            },
            new NnhEmployee
            {
                NnhId = 5,
                NnhName = "Hoang Van E",
                NnhBirthday = new DateTime(1993, 7, 25),
                NnhEmail = "e.hoang@example.com",
                NnhPhone = "0967123456",
                NnhSalary = 16000000,
                NnhStatus = false
            }

        };
        // GET: NnhEmployeeController
        public ActionResult NnhIndex()
        {
            return View(nnhListEmployee);
        }

        // GET: NnhEmployeeController/NnhDetails/5
        public ActionResult NnhDetails(int id)
        {
            var nnhEmployee = nnhListEmployee.FirstOrDefault(x => x.NnhId == id);
            return View(nnhEmployee);
        }

        // GET: NnhEmployeeController/NnhCreate
        public ActionResult NnhCreate()
        {
            var nnhEmployee = new NnhEmployee(); 
            return View();
        }

        // POST: NnhEmployeeController/NnhCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NnhCreate(NnhEmployee nnhModel)
        {
            try
            {
                // Thêm mới nhân viên vào list 
                nnhModel.NnhId = nnhListEmployee.Max(x=>x.NnhId) + 1;
                nnhListEmployee.Add(nnhModel);
                return RedirectToAction(nameof(NnhIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: NnhEmployeeController/NnhEdit/5
        public ActionResult NnhEdit(int id)
        {
            var nnhEmployee = nnhListEmployee.FirstOrDefault(x => x.NnhId == id);
            return View(nnhEmployee);
        }

        // POST: NnhEmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NnhEdit(int id, NnhEmployee nnhModel)
        {
            try
            {
                for (int i = 0; i < nnhListEmployee.Count(); i++)
                {
                    if (nnhListEmployee[i].NnhId == id)
                    {
                        nnhListEmployee[i] = nnhModel;
                        break;
                    }    
                }
                return RedirectToAction(nameof(NnhIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: NnhEmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NnhEmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
