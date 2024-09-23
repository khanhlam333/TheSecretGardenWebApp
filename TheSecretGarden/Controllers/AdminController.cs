using Microsoft.AspNetCore.Mvc;
using TheSecretGarden.Enum;
using TheSecretGarden.Models;
using TheSecretGarden.ViewModels;
using TheSecretGarden.Services;

namespace TheSecretGarden.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBookService _service;
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        public AdminController(IBookService service, IOrderService orderService, ICustomerService customerService)
        {
            _service = service;
            _orderService = orderService;
            _customerService = customerService;
        }
        public async Task<IActionResult> Index()
        {
            var customers = await _customerService.GetCustomers();
            int totalCustomers = 0;

            var orders = await _orderService.GetOrders();
            int totalOrders = 0;

            var orderitems = await _orderService.GetOrderItems();
            double totalSales = 0;

            var books = await _service.GetBooks();
            int totalBooks = 0;

            foreach (var customer in customers)
            {
                totalCustomers += 1;
            }

            foreach (var order in orders)
            {
                totalOrders += 1;
            }

            foreach(var item in orderitems)
            {
                totalSales += item.Amount * item.Book.Price;
            }

            foreach(var book in books)
            {
                totalBooks += 1;
            }

            
            TotalDashboardVM vm = new TotalDashboardVM();
            vm.totalCustomers = totalCustomers;
            vm.totalSales = totalSales;
            vm.totalBooks = totalBooks;
            vm.totalOrders = totalOrders;

            return View(vm);
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

        //Get: Books/Details/1
        public async Task<IActionResult> Details (int id)
        {
            var bookDetails = await _service.GetByIdAsync(id);
            if (bookDetails == null) return View("NotFound");
            return View(bookDetails);
        }

        //Get: Books/Edit/1
        public async Task<IActionResult> Edit (int id)
        {
            var bookDetails = await _service.GetByIdAsync(id);
            if(bookDetails == null) return View("NotFound");
            return View(bookDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, ImgLink, Title, Author, Description, Price, BookCategory")] Book book, IFormFile file)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            if (file != null)
            {
                var Category = book.BookCategory;
                string FileName = file.FileName;

                string oldImgLink = book.ImgLink;
                string oldImgLinkRepl = oldImgLink.Replace("~", "wwwroot");
                
                if(System.IO.File.Exists(oldImgLinkRepl))
                {
                    System.IO.File.Delete(oldImgLinkRepl);
                } 
                

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

                await _service.UpdateAsync(id, book);
                return RedirectToAction("BooksManage");

            }
            
            await _service.UpdateAsync(id, book);
            return RedirectToAction("BooksManage");
        }

        //Get: Books/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var bookDetails = await _service.GetByIdAsync(id);
            if (bookDetails == null) return View("NotFound");
            return View(bookDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookDetails = await _service.GetByIdAsync(id);
            if (bookDetails == null) return View("NotFound");

            string oldImgLink = bookDetails.ImgLink;
            string oldImgLinkRepl = oldImgLink.Replace("~", "wwwroot");

            TempData["message"] = bookDetails.Title + " has been successfully deleted";
            TempData["style"] = "block";

            await _service.DeleteAsync(id);

            if (System.IO.File.Exists(oldImgLinkRepl))
            {
                try
                {
                    System.IO.File.Delete(oldImgLinkRepl);
                }
                catch
                {
                    return RedirectToAction("BooksManage");
                }
            }

            return RedirectToAction("BooksManage");
        }
    }
}
