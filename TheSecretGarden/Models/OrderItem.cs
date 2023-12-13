using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheSecretGarden.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
