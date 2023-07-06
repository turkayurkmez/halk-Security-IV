using AuthzFlowWithMVC.Models;
using AuthzFlowWithMVC.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuthzFlowWithMVC.Controllers
{
    public class KullaniciController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string? nereyeGideyim)
        {

            ViewBag.ReturnUrl = nereyeGideyim;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel userLoginModel, string? nereyeGideyim)
        {
            if (ModelState.IsValid)
            {
                UserService userService = new UserService();
                var user = userService.ValidateUser(userLoginModel.UserName, userLoginModel.Password);
                if (user != null)
                {

                    Claim[] claims =
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role)
                    };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    if (!string.IsNullOrEmpty(nereyeGideyim) && Url.IsLocalUrl(nereyeGideyim))
                    {
                        return Redirect(nereyeGideyim);
                    }
                    return Redirect("/");
                }
                ModelState.AddModelError("login", "Kullanıcı ya da şifre hatalı ");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");

        }

        public IActionResult Yasak()
        {
            return View();
        }
    }
}
