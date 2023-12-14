using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using TheSecretGarden.Models;
using TheSecretGarden.Services;
using Microsoft.AspNetCore.Components.Web;


namespace TheSecretGarden.Controllers
{
    public class LoginController : Controller
    {
        private readonly ICustomerService _service;
        private readonly IHttpContextAccessor _contextAccessor;
        public LoginController(ICustomerService service, IHttpContextAccessor contextAccessor)
        {
            _service = service;
            _contextAccessor = contextAccessor;
        }

        //Get: Login/LoginAccount
        public IActionResult LoginAccount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAccount(Customer customer)
        {
            var data = await _service.GetByUsernameAndPasswordAsync(customer);
            if(data.Username == "AdminTheSecretGarden" && data.Password == "Admin123@TheSecretGarden")
            {
                _contextAccessor.HttpContext.Session.SetString("Role", "Admin");
            }

            _contextAccessor.HttpContext.Session.SetInt32("Id", data.Id);
            _contextAccessor.HttpContext.Session.SetString("Name", data.Name);
            _contextAccessor.HttpContext.Session.SetString("Username", data.Username);
            _contextAccessor.HttpContext.Session.SetString("Email", data.Email);
            _contextAccessor.HttpContext.Session.SetString("Password", data.Password);
            _contextAccessor.HttpContext.Session.SetString("DateRegistered", data.DateRegistered.ToString());
            _contextAccessor.HttpContext.Session.SetString("ActiveState", "active");

            return RedirectToAction("Index", "Home");
        }

        public async Task Login()
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

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
