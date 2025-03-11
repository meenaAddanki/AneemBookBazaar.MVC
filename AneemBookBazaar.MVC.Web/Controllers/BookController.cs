using AneemBookBazaar.MVC.DataAccess;
using AneemBookBazaar.MVC.DataAccess.Repository.IRepository;
using AneemBookBazaar.MVC.Models.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace AneemBookBazaar.MVC.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitofWork;
        public BookController(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;

        }
        public IActionResult Index()
        {
            var bookList = _unitofWork.Book.GetAll();
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
            _unitofWork.Book.Add(book);
            _unitofWork.Save();
            TempData["Success"] = "Book created successfully";
            return RedirectToAction("Index");

        }
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Book book = _unitofWork.Book.Get(u => u.ID == id);
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
            //_context.Books.Update(book);
            //_context.SaveChanges();
            _unitofWork.Book.Update(book);
            _unitofWork.Save();
            TempData["Success"] = "Book updated successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Book book = _unitofWork.Book.Get(x => x.ID == id);
            if (book == null) { return NotFound(); }
            return View(book);

        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            var book = _unitofWork.Book.Get(x => x.ID == id);
            if (book == null) { return NotFound(); }
            _unitofWork.Book.Delete(book);
            _unitofWork.Save();
            TempData["Success"] = "Book deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
