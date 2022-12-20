using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjeKamp.Context;
using ProjeKamp.Models;

namespace ProjeKamp.Controllers
{
    public class AdminController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListAdmin()
        {
            return View();
        }
        public IActionResult ListUser()
        {
            return View();
        }
        public IActionResult CreateCamp()
        {
            return View();
        }
        public IActionResult ListCamp()
        {
            return View();
        }
        public IActionResult GetCampDetails()
        {
            return View();
        }






    }
}