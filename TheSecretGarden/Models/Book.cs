using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheSecretGarden.Enum;

namespace TheSecretGarden.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string? ImgLink { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public BookCategory BookCategory { get; set; }
    }
}
