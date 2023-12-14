using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using TheSecretGarden.Models;
using TheSecretGarden.Services;

namespace TheSecretGarden.Controllers
{
    public class SignupController : Controller
    {
        private readonly ICustomerService _service;
        public SignupController(ICustomerService service)
        {
            _service = service;
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
        public async Task<IActionResult> CreateAccount([Bind("Name, Username, Email, Password, DateRegistered, ActiveState")] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            customer.DateRegistered = DateTime.Now;

            await _service.AddAsync(customer);

            TempData["id"] = customer.Id;
            TempData["name"] = customer.Name;
            TempData["username"] = customer.Username;
            TempData["email"] = customer.Email;
            TempData["password"] = customer.Password;
            TempData["dateregistered"] = customer.DateRegistered.ToString();
            TempData["state"] = customer.ActiveState;

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
            var data = await _service.GetCustomers();
            return View(data);
        }

        //Get: Customes/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var customerDetails = await _service.GetByIdAsync(id);
            if (customerDetails == null) return View("NotFound");
            return View(customerDetails);
        }

        public async Task<IActionResult> LogoutAccount([Bind("Id, Name, Username, Email, Password, DateRegistered, ActiveState")] Customer customer)
        {
            customer.Id = Convert.ToInt32(customer.Id);
            customer.DateRegistered = Convert.ToDateTime(customer.DateRegistered);

            if (!ModelState.IsValid)
            {
                var error = ModelState.Values.SelectMany(v => v.Errors);
                return Json(error);
                //return RedirectToAction("Index", "Login");//change later
            }

            await _service.UpdateAsync(customer);
            return RedirectToAction("Index", "Home");
        }
    }
}
