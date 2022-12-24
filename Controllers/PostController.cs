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
    public class PostController : Controller
    {
        private readonly CampDataContext _context;

        public PostController(CampDataContext context)
        {
            _context = context;
        }

        // GET: Post
        public async Task<IActionResult> Index()
        {
            HttpContext.Request.Cookies.TryGetValue("username", out var value);
            ViewData["username"] = value;
            return View(await _context.Posts.ToListAsync());
        }
        public async Task<IActionResult> ListPost()
        {
            HttpContext.Request.Cookies.TryGetValue("username", out var value);
            ViewData["username"] = value;
            return View(await _context.Posts.ToListAsync());
        }
        public async Task<IActionResult> Record(int? id)
        {
            HttpContext.Request.Cookies.TryGetValue("userId", out var userId);
            Console.WriteLine("post-id: " + id.Value);
            Console.WriteLine("user-id: " + userId);
            if (id != null && userId != null)
            {


                try
                {
                    PostDetail postDetail = new PostDetail();
                    postDetail.postId = id.Value;
                    postDetail.ParticipantId = Convert.ToInt32(userId);
                    _context.Add(postDetail);
                    await _context.SaveChangesAsync();
                }catch(Exception ex)
                {
                    Console.WriteLine("Exception: " + ex);
                    return RedirectToAction("ListPost");

                }



            }
            else
            {
                Console.WriteLine("tepki yok");

            }
            return RedirectToAction("ListPost");
        }

        // GET: Post/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }
            var postDetail = _context.PostDetail.ToList();
            List<User> userList = _context.Users.ToList();
            List<String> usernameList=new List<String>();

            foreach(var detail in postDetail)
            {
                foreach (User user in userList)
                {
                    if (user.UserId == detail.ParticipantId && detail.postId == id)
                    {
                        Console.WriteLine("user: " + user.UserName);
                        usernameList.Add(user.UserName.ToString());
                    }
                }
            }
               

            ViewData["userList"] = usernameList;
            return View(post);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,PostContent,NumberOfParticipants,NumberOfUndecided,AdminId")] Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }
       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: PostController2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Posts == null)
            {
                return Problem("Entity set 'CampDataContext.Posts'  is null.");
            }
            var post = await _context.Posts.FindAsync(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("ListCamp", "Admin");
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.PostId == id);
        }



    }
}
