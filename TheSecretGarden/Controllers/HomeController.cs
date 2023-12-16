using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheSecretGarden.Models;
using TheSecretGarden.Services;

namespace TheSecretGarden.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _service;
        public HomeController(IBookService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetBooks();
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
