using Microsoft.AspNetCore.Mvc;
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