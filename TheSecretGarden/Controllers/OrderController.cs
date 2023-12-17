using Azure.Identity;
using Microsoft.AspNetCore.Mvc;
using TheSecretGarden.Models;
using TheSecretGarden.Services;
using TheSecretGarden.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TheSecretGarden.Controllers
{
    public class OrderController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;

        private readonly IHttpContextAccessor _contextAccessor;

        public OrderController(IBookService bookService, ShoppingCart shoppingCart, IOrderService orderService, ICustomerService customerService, IHttpContextAccessor contextAccessor)
        {
            _bookService = bookService;
            _shoppingCart = shoppingCart;
            _orderService = orderService;
            _customerService = customerService;
            _contextAccessor = contextAccessor;
        }

        public async Task<IActionResult> OrdersManage()
        {
            var data = await _orderService.GetOrders();
            return View(data);
        }
        public async Task<IActionResult> YourOrder()
        {
            var data = await _customerService.GetByUsername(Request.Cookies["Username"]);
            int customerId = data.Id;

            var orders = await _orderService.GetOrdersByCustomerId(customerId);
            return View(orders);
        }

        public async Task<IActionResult> Details(int id)
        {
            var orderDetails = await _orderService.GetOrderItemsByOrderId(id);
            if (orderDetails == null) return View("NotFound");
            return View(orderDetails);
        }

        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            _contextAccessor.HttpContext.Session.SetInt32("NumberInBasket", items.Count());

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }

        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _bookService.GetByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> AddItemToShoppingCartStay(int id)
        {
            var item = await _bookService.GetByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction("ShoppingCart", "Order");
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart (int id)
        {
            var item = await _bookService.GetByIdAsync (id);

            if(item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction("ShoppingCart", "Order");
        }

        public IActionResult OrderCompleted()
        {
            return View();
        }

        public async Task<IActionResult> CompleteOrder()
        {
            _contextAccessor.HttpContext.Session.SetInt32("NumberInBasket", 0);

            var items = _shoppingCart.GetShoppingCartItems();
            var data = await _customerService.GetByUsername(Request.Cookies["Username"]);
            int customerId = data.Id;
            string customerEmail = data.Email;

            await _orderService.StoreOrderAsync(items, customerId, customerEmail);
            await _shoppingCart.ClearShoppingCartAsync();

            return RedirectToAction("OrderCompleted", "Order");
        }
    }
}
