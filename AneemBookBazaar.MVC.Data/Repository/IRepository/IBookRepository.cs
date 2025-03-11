using AneemBookBazaar.MVC.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AneemBookBazaar.MVC.DataAccess.Repository.IRepository
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        void Update(Book book);
        void Save(Book book);
    }
}
