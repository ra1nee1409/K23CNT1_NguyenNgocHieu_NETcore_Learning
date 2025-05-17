using Day3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace Day3.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            List<Account> accounts = new List<Account>
            {
                 new Account ()
                 {
                 Id = 1,
                 Name = "Nguyễn Ngọc Hiếu",
                 Email = "sthieudeptrai@gmail.com",
                 Phone="0123456789",
                 Address = "HaNoi",
                 Avatar= Url.Content("~/Avatar/1.jpg"),
                 Gender= 1,
                 Bio= "my name is small",
                 Birthday=new DateTime(2005,9,14),
                 },
                 new Account ()
                 {
                 Id = 2,
                 Name = "Nguyễn Đẹp Trai",
                 Email = "deptraideptrai.com",
                 Phone="9876543210",
                 Address = "NinhBinh",
                 Avatar= Url.Content("~/Avatar/2.jpg"),
                 Gender= 1,
                 Bio= "my name is small",
                 Birthday=new DateTime(2007,4,16),
                 },
                 new Account ()
                 {
                 Id = 3,
                 Name = "Trần Gà Luộc",
                 Email = "trangaluon.com",
                 Phone="123123123",
                 Address = "HaiDuong",
                 Avatar= Url.Content("~/Avatar/3.jpg"),
                 Gender= 1,
                 Bio= "my name is small",
                 Birthday=new DateTime(2002,4,21),
                 },
            };
            ViewBag.Accounts = accounts;
            return View();
        }

        [Route("ho-so-cua-toi", Name = "profile")]
        public IActionResult Profile(int id)
        {
            List<Account> accounts = new List<Account>
            {
                new Account
            {
            Id = 1,
            Name = "Nguyễn Ngọc Hiếu",
            Email = "sthieudeptrai@gmail.com",
            Phone = "0123456789",
            Address = "HaNoi",
            Avatar = Url.Content("~/Avatar/1.jpg"),
            Gender = 1,
            Bio = "my name is small",
            Birthday = new DateTime(2005, 9, 14),
            },
                new Account
            {
            Id = 2,
            Name = "Nguyễn Đẹp Trai",
            Email = "deptraideptrai@gmail.com",
            Phone = "9876543210",
            Address = "NinhBinh",
            Avatar = Url.Content("~/Avatar/2.jpg"),
            Gender = 1,
            Bio = "handsome guy here",
            Birthday = new DateTime(2007, 4, 16),
            },
                new Account
            {
            Id = 3,
            Name = "Trần Gà Luộc",
            Email = "trangaluoc@gmail.com",
            Phone = "123123123",
            Address = "HaiDuong",
            Avatar = Url.Content("~/Avatar/3.jpg"),
            Gender = 1,
            Bio = "chicken lover",
            Birthday = new DateTime(2002, 4, 21),
            },
        };

            var account = accounts.FirstOrDefault(a => a.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            ViewBag.Account = account;
            return View();
        }
    }
}
