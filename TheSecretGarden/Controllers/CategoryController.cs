using Microsoft.AspNetCore.Mvc;

namespace TheSecretGarden.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Fiction()
        {
            return View();
        }

        public IActionResult NonFiction()
        {
            return View();
        }

        public IActionResult LimitedEdition()
        {
            return View();
        }
    }
}
