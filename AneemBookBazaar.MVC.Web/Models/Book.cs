using System.ComponentModel.DataAnnotations;

namespace AneemBookBazaar.MVC.Web.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "An Album Title is required")]
        public string Name { get; set; }
        public int Isbn { get; set; }
    }
}
