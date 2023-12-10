using Microsoft.AspNetCore.Mvc;

namespace TheSecretGarden.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BooksManage()
        {
            return View();
        }

        public IActionResult OrdersManage()
        {
            return View();
        }

        public IActionResult CustomersManage()
        {
            return View();
        }
    }
}
