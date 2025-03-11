using AneemBookBazaar.MVC.DataAccess.Repository.IRepository;
using AneemBookBazaar.MVC.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AneemBookBazaar.MVC.DataAccess.Repository
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        private readonly ApplicationDbContext _db;
        public BookRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save(Book book)
        {
            throw new NotImplementedException();
        }

        public void Update(Book book)
        {
            _db.Update(book);
        }
    }
}
