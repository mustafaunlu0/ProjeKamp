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
        private readonly CampDataContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;


        public AdminController(CampDataContext context, IWebHostEnvironment webContext)
        {
            _context = context;
            webHostEnvironment = webContext;

        }

        public IActionResult Index()
        {
            ViewData["Admins"]=_context.Users.Where(x => x.RoleId == 1).ToList();
            ViewData["Users"] = _context.Users.Where(x => x.RoleId == 2).ToList();
            ViewData["Posts"]=_context.Posts.ToList();
            return View();
        }

        public async Task<IActionResult> ListAdmin()
        {
            List<User> admins = _context.Users.Where(x => x.RoleId == 1).ToList();
            return View(admins);
        }
        public IActionResult ListUser()
        {
            List<User> users = _context.Users.Where(x => x.RoleId == 2).ToList();
            return View(users);
        }
        public IActionResult CreateCamp()
        {
            Console.WriteLine("CreateCamp");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCamp([Bind("PostId,PostName,PostCity,PostCounty,PostDate,PostHour,NumberOfParticipants,PostUri,PostImage,PostContent,AdminId")] Post post, IFormFile file)
        {
            if (post != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + post.PostImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    post.PostImage.CopyTo(fs);
                }

                Console.WriteLine("sonuc:" + uniqueFileName);
                post.PostUri = uniqueFileName;

                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ListCamp()
        {
            
            return View(await _context.Posts.OrderByDescending(x => x.PostDate).ToListAsync());

        }


        public IActionResult GetCampDetails()
        {
            return View();
        }


        public async Task<IActionResult> EditAdmin(int? id)
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

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAdmin(int id, [Bind("UserId,UserName,UserLastName,UserEmail,UserPassword")] User user)
        {
            user.RoleId = 1;
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
                return RedirectToAction("ListAdmin");
            }
            return View(user);
        }
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }



    }
}