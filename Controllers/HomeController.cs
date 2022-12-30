using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using ProjeKamp.Context;
using ProjeKamp.Models;
using System.Diagnostics;

namespace ProjeKamp.Controllers
{
    public class HomeController : Controller
    {

        //Dil Dsteği
        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            return Redirect(Request.Headers["Referer"].ToString());
        }


        public IActionResult Index()
        {
            return View();
        }
        
        


    }
}