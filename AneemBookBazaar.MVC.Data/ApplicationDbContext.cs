using AneemBookBazaar.MVC.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace AneemBookBazaar.MVC.DataAccess
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}