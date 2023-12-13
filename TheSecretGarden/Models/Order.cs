using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheSecretGarden.Enum;


namespace TheSecretGarden.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId {  get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public DateTime DatePlacedOrder { get; set; }
        public double TotalCost {  get; set; }
        public Status Status { get; set; }
    }
}
