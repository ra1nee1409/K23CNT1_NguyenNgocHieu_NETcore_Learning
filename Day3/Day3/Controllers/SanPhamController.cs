using Microsoft.AspNetCore.Mvc;
using Day3.Models;

namespace Day3.Controllers
{
    public class SanPhamController : Controller
    {
        public IActionResult NnhSanPham()
        {
            List<NnhSanPham> accountsSp = new List<NnhSanPham>
            {
                new NnhSanPham()
                {
                    IdSp = 1,
                    NameSp = "Bong Sen Vang",
                    Gia = "300000",
                    MoTa = "tot",
                    AvatarSp = Url.Content("~/img/04.jpg"), // Updated image path
                    TrangThai = "Tot",
                    BioSp = "Bong Sen RAT Vang",
                    NgayDang = new DateTime(2025, 10, 22),
                },
                new NnhSanPham()
                {
                    IdSp = 2,
                    NameSp = "Cay cam ngot cua toi",
                    Gia = "300000",
                    MoTa = "tot",
                    AvatarSp = Url.Content("~/img/05.jpg"), // Updated image path
                    TrangThai = "Tot",
                    BioSp = "Cam RAT ngot",
                    NgayDang = new DateTime(2025, 10, 22),
                },
                new NnhSanPham()
                {
                    IdSp = 3,
                    NameSp = "Thai Bach Kim Tinh",
                    Gia = "300000",
                    MoTa = "tot",
                    AvatarSp = Url.Content("~/img/06.jpg"), // Updated image path
                    TrangThai = "Tot",
                    BioSp = "Thai Bach Chym Tinh",
                    NgayDang = new DateTime(2025, 10, 22),
                },
                new NnhSanPham()
                {
                    IdSp = 4,
                    NameSp = "The Green Lotus Bud",
                    Gia = "300000",
                    MoTa = "tot",
                    AvatarSp = Url.Content("~/img/07.jpg"), // Updated image path
                    TrangThai = "Tot",
                    BioSp = "my name is small",
                    NgayDang = new DateTime(2025, 10, 22),
                },
                new NnhSanPham()
                {
                    IdSp = 5,
                    NameSp = "Cho toi xin mot ve di tuoi tho",
                    Gia = "300000",
                    MoTa = "tot",
                    AvatarSp = Url.Content("~/img/08.jpg"), // Updated image path
                    TrangThai = "Tot",
                    BioSp = "1 ticket pls",
                    NgayDang = new DateTime(2025, 10, 22),
                },
                new NnhSanPham()
                {
                    IdSp = 6,
                    NameSp = "Hanh lang hai lop",
                    Gia = "300000",
                    MoTa = "tot",
                    AvatarSp = Url.Content("~/img/09.jpg"), // Updated image path
                    TrangThai = "Tot",
                    BioSp = "Hanh lanh nhieu lop",
                    NgayDang = new DateTime(2025, 10, 22),
                }
            };

            // ✅ Truyền danh sách sang View
            ViewBag.accounts = accountsSp;

            return View();

        }
        [Route("Chi-tier-san-pham", Name = "sanPham")]
        public IActionResult NnhChiTietSanPham(int idsp)
        {
            List<NnhSanPham> sanPhams = new List<NnhSanPham>() {
                new NnhSanPham()
                {
                    IdSp = 1,
                    NameSp = "Bong Sen Vang",
                    Gia = "300000",
                    MoTa = "tot",
                    AvatarSp = Url.Content("~/img/04.jpg"), // Updated image path
                    TrangThai = "Tot",
                    BioSp = "Bong Sen RAT Vang",
                    NgayDang = new DateTime(2025, 10, 22),
                },
                new NnhSanPham()
                {
                    IdSp = 2,
                    NameSp = "Cay cam ngot cua toi",
                    Gia = "300000",
                    MoTa = "tot",
                    AvatarSp = Url.Content("~/img/05.jpg"), // Updated image path
                    TrangThai = "Tot",
                    BioSp = "Cam RAT ngot",
                    NgayDang = new DateTime(2025, 10, 22),
                },
                new NnhSanPham()
                {
                    IdSp = 3,
                    NameSp = "Thai Bach Kim Tinh",
                    Gia = "300000",
                    MoTa = "tot",
                    AvatarSp = Url.Content("~/img/06.jpg"), // Updated image path
                    TrangThai = "Tot",
                    BioSp = "Thai Bach Chym Tinh",
                    NgayDang = new DateTime(2025, 10, 22),
                },
                new NnhSanPham()
                {
                    IdSp = 4,
                    NameSp = "The Green Lotus Bud",
                    Gia = "300000",
                    MoTa = "tot",
                    AvatarSp = Url.Content("~/img/07.jpg"), // Updated image path
                    TrangThai = "Tot",
                    BioSp = "my name is small",
                    NgayDang = new DateTime(2025, 10, 22),
                },
                new NnhSanPham()
                {
                    IdSp = 5,
                    NameSp = "Cho toi xin mot ve di tuoi tho",
                    Gia = "300000",
                    MoTa = "tot",
                    AvatarSp = Url.Content("~/img/08.jpg"), // Updated image path
                    TrangThai = "Tot",
                    BioSp = "1 ticket pls",
                    NgayDang = new DateTime(2025, 10, 22),
                },
                new NnhSanPham()
                {
                    IdSp = 6,
                    NameSp = "Hanh lang hai lop",
                    Gia = "300000",
                    MoTa = "tot",
                    AvatarSp = Url.Content("~/img/09.jpg"), // Updated image path
                    TrangThai = "Tot",
                    BioSp = "Hanh lanh nhieu lop",
                    NgayDang = new DateTime(2025, 10, 22),
                }
            };

            // Tìm sản phẩm theo id
            NnhSanPham sanpham = sanPhams.FirstOrDefault(ac => ac.IdSp == idsp);

            if (sanpham == null)
            {
                return NotFound(); // hoặc chuyển hướng, hoặc thông báo lỗi
            }

            // Gửi sản phẩm tìm được sang view
            ViewBag.SanPham = sanpham;

            return View();
        }
    }
}
