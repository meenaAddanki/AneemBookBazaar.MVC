using AneemBookBazaar.MVC.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AneemBookBazaar.MVC.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var bookList = _context.Books.ToList();
            return View(bookList);
            
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            _context.Books.Add(book);
            _context.SaveChanges();

            TempData["Success"] = "Book created successfully";
            return RedirectToAction("Index");

        }
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Book book = _context.Books.FirstOrDefault(x=> x.ID == id);
            if (book == null) { return NotFound(); }
            return View(book);

        }
        [HttpPost]
        public IActionResult Update(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            _context.Books.Update(book);
            _context.SaveChanges();

            TempData["Success"] = "Book updated successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Book book = _context.Books.FirstOrDefault(x => x.ID == id);
            if (book == null) { return NotFound(); }
            return View(book);

        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            var book = _context.Books.FirstOrDefault(x => x.ID == id);
            if (book == null) { return NotFound(); }
            _context.Books.Remove(book);
            _context.SaveChanges();
            TempData["Success"] = "Book deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
