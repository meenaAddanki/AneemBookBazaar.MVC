using AneemBookBazaar.MVC.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AneemBookBazaar.MVC.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public IBookRepository Book { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Book = new BookRepository(_context);

        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}