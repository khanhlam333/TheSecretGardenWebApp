using TheSecretGarden.Models;

namespace TheSecretGarden.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrders();
        Task StoreOrderAsync(List<ShoppingCartItem> items, int customerId, string customerEmail);
        Task<List<Order>> GetOrdersByCustomerId(int customerId);
        Task<IEnumerable<OrderItem>> GetOrderItemsByOrderId(int orderId);
    }
}
