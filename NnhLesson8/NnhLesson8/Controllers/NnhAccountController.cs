using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NnhLesson8.Models;
using System.Text.RegularExpressions;

namespace NnhLesson8.Controllers
{
    public class NnhAccountController : Controller
    {
        
        // GET: NnhAccountController

        public ActionResult NnhIndex()
        {
            List<Account> accounts = new List<Account>()
            {
                new Account 
                {
                Id = 1,
                FullName = "Nguyễn Văn A",
                Email = "vana@example.com",
                Phone = "0986421127",
                Address = "Hà Nội",
                Avatar = "avatar1.png",
                Birthday = new DateTime(1990, 5, 20),
                Gender = "Nam",
                Password = "password1",
                Facebook = "https://facebook.com/vana"
                },
                new Account 
                {
                Id = 2,
                FullName = "Trần Thị B",
                Email = "thib@example.com",
                Phone = "0912345678",
                Address = "Hồ Chí Minh",
                Avatar = "avatar2.png",
                Birthday = new DateTime(1985, 3, 15),
                Gender = "Nữ",
                Password = "password2",
                Facebook = "https://facebook.com/thib"
                },
                new Account 
                {
                Id = 3,
                FullName = "Lê Văn C",
                Email = "vanc@example.com",
                Phone = "0977654321",
                Address = "Đà Nẵng",
                Avatar = "avatar3.png",
                Birthday = new DateTime(1992, 7, 10),
                Gender = "Nam",
                Password = "password3",
                Facebook = "https://facebook.com/vanc"
                },
                new Account 
                {
                Id = 4,
                FullName = "Phạm Thị D",
                Email = "thid@example.com",
                Phone = "0909123456",
                Address = "Cần Thơ",
                Avatar = "avatar4.png",
                Birthday = new DateTime(1995, 11, 5),
                Gender = "Nữ",
                Password = "password4",
                Facebook = "https://facebook.com/thid"
                },
                new Account 
                {
                Id = 5,
                FullName = "Hoàng Văn E",
                Email = "vane@example.com",
                Phone = "0933777888",
                Address = "Hải Phòng",
                Avatar = "avatar5.png",
                Birthday = new DateTime(1988, 1, 25),
                Gender = "Nam",
                Password = "password5",
                Facebook = "https://facebook.com/vane"
                },

            };
            

            return View(accounts);
        }

        // Danh sách tạm thời lưu trên bộ nhớ (có thể dùng database sau)
        public static List<Account> nnhAccounts = new List<Account>();
        [AcceptVerbs("GET","POST")]

        // GET: NnhAccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NnhAccountController/NnhCreate
        public ActionResult NnhCreate()
        {
            Account model = new Account();
            return View(model);
        }
        [AcceptVerbs("GET", "POST")]
        public ActionResult VerifyPhone(string phone)
        {
            var isPhone = new Regex(@"^\(?([0-9]{3})\)?[-.]?([0-9]{3})[-.]?([0-9]{4})$");
            if (!isPhone.IsMatch(phone))
            {
                return Json($"Số điện thoại {phone} VD: 0986421127 hoặc 098.421.1127");
            }
            return Json(true);
        }

        // POST: NnhAccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: NnhAccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NnhAccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: NnhAccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NnhAccountController/Delete/5
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
