using Microsoft.AspNetCore.Mvc;
using TheSecretGarden.Enum;
using TheSecretGarden.Services;

namespace TheSecretGarden.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IBookService _service;
        public CategoryController(IBookService service)
        {
            _service = service;  
        }
        public async Task<IActionResult> Fiction()
        {
            var data = await _service.GetByCategoryAsync(BookCategory.Fiction);
            return View(data);
        }

        public async Task<IActionResult> NonFiction()
        {
            var data = await _service.GetByCategoryAsync(BookCategory.NonFiction);
            return View(data);
        }

        public async Task<IActionResult> LimitedEdition()
        {
            var data = await _service.GetByCategoryAsync(BookCategory.LimitedEdition);
            return View(data);
        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null)
            {
                return View("NotFound");
            }
            return View(data);
        }
    }
}
