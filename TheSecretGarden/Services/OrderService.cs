using TheSecretGarden.Models;
using Microsoft.EntityFrameworkCore;

namespace TheSecretGarden.Services
{
    public class OrderService : IOrderService
    {
        private readonly BookStoreDbContext _context;
        public OrderService(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            var result = await _context.Orders.ToListAsync();
            return result;
        }

        public async Task<List<Order>> GetOrdersByCustomerId(int customerId)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Book).Include(n => n.Customer).ToListAsync();

            orders = orders.Where(n => n.CustomerId == customerId).ToList();
            return orders;
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItemsByOrderId(int orderId)
        {
            var orderitems = await _context.OrderItems.Include(n => n.Book).Include(n => n.Order).ToListAsync();

            orderitems = orderitems.Where(n => n.OrderId == orderId).ToList();
            return orderitems;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, int customerId, string customerEmail)
        {
            var order = new Order()
            {
                CustomerId = customerId,
                Email = customerEmail
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach(var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    BookId = item.Book.Id,
                    OrderId = order.Id,
                    Price = item.Book.Price
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
