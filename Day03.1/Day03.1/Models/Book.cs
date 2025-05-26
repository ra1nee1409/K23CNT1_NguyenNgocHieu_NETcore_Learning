using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Day03._1.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string Sumary { get; set; }

        // Danh sách các cuốn sách 
        public static List<Book> GetBookList()
        {
            return new List<Book>()
            {
                new Book{ Id = 1, Title = "Nhật ký Đặng Thuỳ Trâm", AuthorId = 1, GenreId = 1, Image = "/images/products/01.jpg", Price = 500000, TotalPage = 250, Sumary = "" },
                new Book{ Id = 2, Title = "Trường ca Achilles", AuthorId = 2, GenreId = 2, Image = "/images/products/02.jpg", Price = 500000, TotalPage = 250, Sumary = "" },
                new Book{ Id = 3, Title = "Người đàn ông mang tên OVE", AuthorId = 3, GenreId = 3, Image = "/images/products/03.jpg", Price = 500000, TotalPage = 250, Sumary = "" },
                new Book{ Id = 4, Title = "Bông Sen Vàng", AuthorId = 4, GenreId = 4, Image = "/images/products/04.jpg", Price = 500000, TotalPage = 250, Sumary = "" }
            };
        }

        // Chi tiết 1 cuốn sách theo id
        public Book GetBookById(int id)
        {
            return GetBookList().FirstOrDefault(b => b.Id == id);
        }

        // SelectListItem Authors (dành cho ComboBox)
        public List<SelectListItem> Authors { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Đặng Thuỳ Trâm" },
            new SelectListItem { Value = "2", Text = "Madeline Miller" },
            new SelectListItem { Value = "3", Text = "Hoàng Anh" },
            new SelectListItem { Value = "4", Text = "Thiền sư Thích Nhất Hạnh" }
        };

        // SelectListItem Genres (dành cho ComboBox)
        public List<SelectListItem> Genres { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Truyện tranh" },
            new SelectListItem { Value = "2", Text = "Văn học đường đời" },
            new SelectListItem { Value = "3", Text = "Phát học phổ thông" },
            new SelectListItem { Value = "4", Text = "Truyện cười" }
        };
    }
}
