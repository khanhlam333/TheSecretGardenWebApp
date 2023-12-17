using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using TheSecretGarden.Models;
using TheSecretGarden.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore.Metadata;
using TheSecretGarden.ViewModels;

namespace TheSecretGarden.Controllers
{
    public class SignupController : Controller
    {
        private readonly ICustomerService _service;
        private readonly IOrderService _orderService;

        private readonly IHttpContextAccessor _contextAccessor;
        public SignupController(ICustomerService service, IOrderService orderService ,IHttpContextAccessor contextAccessor)
        {
            _service = service;
            _orderService = orderService;
            _contextAccessor = contextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Get: Signup/CreateAccount
        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([Bind("Name, Username, Email, Password, DateRegistered")] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            customer.DateRegistered = DateTime.Now;

            await _service.AddAsync(customer);

            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Append("Username", customer.Username, options);

            _contextAccessor.HttpContext.Session.SetInt32("Id", customer.Id);
            _contextAccessor.HttpContext.Session.SetString("Name", customer.Name);
            _contextAccessor.HttpContext.Session.SetString("Username", customer.Username);
            _contextAccessor.HttpContext.Session.SetString("Email", customer.Email);
            _contextAccessor.HttpContext.Session.SetString("Password", customer.Password);
            _contextAccessor.HttpContext.Session.SetString("DateRegistered", customer.DateRegistered.ToString());
            _contextAccessor.HttpContext.Session.SetString("ActiveState", "active");

            return RedirectToAction("Index", "Home");
        }

        public async Task SignupGoogle()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleResponse")
            });
        }
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(claim => new
            {
                claim.Issuer,
                claim.OriginalIssuer,
                claim.Type,
                claim.Value
            });
            var array = Json(claims);
            return RedirectToAction("Index", "Home");
        }

        //Get: Customer
        public async Task<IActionResult> CustomersManage()
        {
            var customerData = await _service.GetCustomers();
            List<int> NumberOfOrders = new List<int>();
            List<double> TotalSpend = new List<double>();
            foreach (var customer in customerData)
            {
                var ordersData = await _orderService.GetOrdersByCustomerId(customer.Id);
                var number = ordersData.Count();
                NumberOfOrders.Add(number);
                double total = 0;
                foreach (var order in ordersData)
                {
                    var orderitemsData = await _orderService.GetOrderItemsByOrderId(order.Id);
                    
                    foreach(var orderitem in orderitemsData)
                    {
                        total += orderitem.Book.Price * orderitem.Amount;
                    }
                }
                TotalSpend.Add(total);
            }
            CustomerOrdersOrderItemsVM vm = new CustomerOrdersOrderItemsVM();
            vm.Customers = customerData;
            vm.NumberOfOrders = NumberOfOrders;
            vm.TotalSpend = TotalSpend;

            return View(vm);
        }

        //Get: Customes/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var customerDetails = await _service.GetByIdAsync(id);
            if (customerDetails == null) return View("NotFound");
            return View(customerDetails);
        }

        public IActionResult LogoutAccount(Customer customer)
        {
            _contextAccessor.HttpContext.Session.SetString("ActiveState", "inactive");
            _contextAccessor.HttpContext.Session.SetString("Role", "None");

            return RedirectToAction("Index", "Home");
        }
    }
}
