using Microsoft.AspNetCore.Mvc;
using TheSecretGarden.Enum;
using TheSecretGarden.Models;
using TheSecretGarden.Services;

namespace TheSecretGarden.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBookService _service;
        public AdminController(IBookService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> BooksManage()
        {
            var data = await _service.GetBooks();
            return View(data);
        }

        //Get: Admin/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ImgLink, Title, Author, Description, Price, BookCategory")]Book book, IFormFile file)
        {
            if(!ModelState.IsValid) //if the model is valid then we will add book to the database
            {
                return View(book);
            }
            if (file != null)
            {
                var Category = book.BookCategory;
                string FileName = file.FileName;
                if (Category == BookCategory.Fiction)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos/fiction", FileName);
                    var stream = new FileStream(path, FileMode.Append);
                    _ = file.CopyToAsync(stream);
                    string link = "~/photos/fiction/" + FileName;
                    book.ImgLink = link;
                }
                else if (Category == BookCategory.NonFiction)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos/non-fiction", FileName);
                    var stream = new FileStream(path, FileMode.Append);
                    _ = file.CopyToAsync(stream);
                    string link = "~/photos/non-fiction/" + FileName;
                    book.ImgLink = link;
                }
                else if (Category == BookCategory.LimitedEdition)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos/limited-editions", FileName);
                    var stream = new FileStream(path, FileMode.Append);
                    _ = file.CopyToAsync(stream);
                    string link = "~/photos/limited-editions/" + FileName;
                    book.ImgLink = link;
                }

                await _service.AddAsync(book);
                return RedirectToAction("BooksManage");

            }
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
