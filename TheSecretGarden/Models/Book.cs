using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheSecretGarden.Enum;

namespace TheSecretGarden.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Book Image")]
        public string ImgLink { get; set; }

        [Required(ErrorMessage = "Title of book is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author of book is required")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Price of book is required")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Description of book is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Category of book is required")]
        [Display(Name = "Category")]
        public BookCategory BookCategory { get; set; }
    }
}
