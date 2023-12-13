using System.ComponentModel.DataAnnotations;

namespace TheSecretGarden.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password {  get; set; }
        public DateTime DateRegistered { get; set; }
        public string Address { get; set; }
        public string Phone {  get; set; }
        public string ActiveState {  get; set; }
        public int OrdersNumber {  get; set; }
        public double TotalSpend {  get; set; }

    }
}
