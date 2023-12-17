using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheSecretGarden.Models;
using TheSecretGarden.Services;

namespace TheSecretGarden.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _service;
        private readonly ShoppingCart _shoppingCart;
        private readonly IHttpContextAccessor _contextAccessor;
        public HomeController(IBookService service, ShoppingCart shoppingCart, IHttpContextAccessor contextAccessor)
        {
            _service = service;
            _shoppingCart = shoppingCart;
            _contextAccessor = contextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetBooks();

            var items = _shoppingCart.GetShoppingCartItems();
            _contextAccessor.HttpContext.Session.SetInt32("NumberInBasket", items.Count());

            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MustLoginOrSignup()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
