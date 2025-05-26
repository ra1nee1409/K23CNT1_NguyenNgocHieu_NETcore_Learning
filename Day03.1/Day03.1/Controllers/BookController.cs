using Microsoft.AspNetCore.Mvc;
using Day03._1.Models;

namespace Day03._1.Controllers
{
    public class BookController : Controller
    {
        // Khởi tạo đối tượng Book để gọi thuộc tính Authors và Genres
        protected Book book = new Book();

        public IActionResult Index()
        {
            // Truyền dữ liệu authors và genres ra View thông qua ViewBag
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;

            // Truyền danh sách book ra view
            var books = Book.GetBookList();
            return View(books);
        }

        public IActionResult Create()
        {
            ViewBag.authors = book.Authors;
            ViewBag.Genres = book.Genres;
            Book model = new Book();
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;
            Book model = book.GetBookById(id);
            return View(model);
        }
    }
}
