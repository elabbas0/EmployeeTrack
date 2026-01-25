using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

public class AccountController : Controller
{
    public IActionResult Login()
    {
        return View();
    } // show login page

    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        if (username == "rehim" && password == "coolboy") // simple hardcoded check
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username)
            }; // create user claims 

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme); //store claims in identity

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index", "Home");
        }

        ViewBag.Message = "Invalid login";
        return View();
    }

    //logout 
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login");
    }

    public IActionResult AccessDenied()
    {
        return View();
    }
}
