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

        private readonly CampDataContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(CampDataContext context, IWebHostEnvironment webContext)
        {
            _context = context;
            webHostEnvironment = webContext;
        }
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
        
        public IActionResult Feed()
        {
            return View();
        }
        
        


    }
}