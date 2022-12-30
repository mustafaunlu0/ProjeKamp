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
    public class UserController : Controller
    {
        private readonly CampDataContext _context;

        public UserController(CampDataContext context)
        {
            _context = context;
        }

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp([Bind("UserId,UserName,UserLastName,UserEmail,UserPassword")] User user)
        {
            user.RoleId = 2;
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                HttpContext.Response.Cookies.Append("username", user.UserName);
                HttpContext.Response.Cookies.Append("userId", user.UserId.ToString());
                return RedirectToAction("ListPost","Post");
            }
            return View(user);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserName,UserLastName,UserEmail,UserPassword")] User user)
        {
            user.RoleId = 2;
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("ListUser","Admin");
            }
            return View(user);
        }


        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email,string key)
        {


            foreach ( var item in _context.Users)
            {
                Console.WriteLine(item.UserEmail);
                if (item.UserEmail.ToString() == email && item.UserPassword.ToString() == key)
                {
                    if (item.RoleId == 1)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    //Cookiler ile kullanıcıyı taşı
                    HttpContext.Response.Cookies.Append("username", item.UserName);
                    HttpContext.Response.Cookies.Append("userId", item.UserId.ToString());

                    return RedirectToAction("ListPost","Post");
                }
            }
            return View();
        }



  
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserName,UserLastName,UserEmail,UserPassword")] User user)
        {
            user.RoleId = 2;
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("ListUser","Admin");
            }
            return View(user);
        }

   
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'CampDataContext.Users'  is null.");
            }
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("ListUser","Admin");
        }

        private bool UserExists(int id)
        {
          return _context.Users.Any(e => e.UserId == id);
        }

        //Cookie veri yollama
        public void SetCookie(string key, string value)
        {
            HttpContext.Response.Cookies.Append(key, value);
        }
        //Cookie veri alma
        public string GetCookie(string key)
        {
            HttpContext.Request.Cookies.TryGetValue(key, out var value);
            return value;
        }
    }
}
