using TheSecretGarden.Models;

namespace TheSecretGarden.ViewModels
{
    public class CustomerOrdersOrderItemsVM
    {
        public IEnumerable<Customer> Customers { get; set; }
        public List<int> NumberOfOrders { get; set; }
        public List<double> TotalSpend { get; set; }
    }
}
