using AneemBookBazaar.MVC.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AneemBookBazaar.MVC.Web
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