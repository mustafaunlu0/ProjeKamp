using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

        //Web Api
        // GET: Post
        public async Task<IActionResult> Index()
        {
            HttpContext.Request.Cookies.TryGetValue("username", out var value);
            ViewData["username"] = value;
            List<Post> posts=new List<Post>();
            var http=new HttpClient();
            var response= await http.GetAsync("https://localhost:7253/api/PostAPI");
            string resString = await response.Content.ReadAsStringAsync();
            posts= JsonConvert.DeserializeObject<List<Post>>(resString);
            return View(posts);
        }
        public async Task<IActionResult> ListPost()
        {
            HttpContext.Request.Cookies.TryGetValue("username", out var value);
            ViewData["username"] = value;

            //Kullanıcı postları getirme
            List<Post> posts = new List<Post>();
            var user = _context.Users.Where(x => x.UserName == value).FirstOrDefault();
            List<PostDetail> postDetail =_context.PostDetail.Where(x => x.ParticipantId == user.UserId).ToList();
            foreach(var postDetay in postDetail)
            {
                posts.Add(_context.Posts.Where(x => x.PostId == postDetay.postId).FirstOrDefault());
            }

            ViewData["posts"]=posts;




            //Date Sıralama
            List<string> dateList = _context.Posts.Select(x => x.PostDate).ToList();
            List<DateTime> dateList2 = new List<DateTime>();


            //Deneme verisi
            ViewData["postForModal"] = _context.Posts.FirstOrDefault();
            ViewData["userListForModal"] = _context.Users.ToList();

            return View(await _context.Posts.ToListAsync());
        }
      
        //LINQ
        public async Task<IActionResult> ListPostFilter(string reportID)
        {
            Console.WriteLine("reportId: " + reportID);

            List<Post> newpost = _context.Posts.Where(x => x.PostCity == reportID).ToList();
            Console.WriteLine("size: " + newpost.Count);

            return View(newpost);

        }

        [HttpGet]
        public IActionResult Filter(string reportID)
        {
            

            return RedirectToAction("ListPostFilter",new { reportID });
           
        }
        [HttpGet]
        public IActionResult GetDetailForModal(int reportID,string username)
        {
       


            ViewData["userDetail"] = _context.Users.Where(x => x.UserName == username).FirstOrDefault();
            ViewData["postForModal"]=_context.Posts.Where(x => x.PostId == reportID).FirstOrDefault();
            List<PostDetail> userList=_context.PostDetail.Where(x => x.postId == reportID).ToList();
            List<User> userListForModal=new List<User>();
            foreach(var item in userList)
            {
                userListForModal.Add(_context.Users.Where(x => x.UserId == item.ParticipantId).FirstOrDefault());
            }
            ViewData["userListForModal"]=userListForModal;
            Console.WriteLine("userListForModal: " + userListForModal.Count);
            return View();

        }



        //LINQ var
        public async Task<IActionResult> Record(int? id)
        {
            
            HttpContext.Request.Cookies.TryGetValue("userId", out var userId);
            if (id != null && userId != null)
            {
                try
                {
                    PostDetail postDetail = new PostDetail();
                    postDetail.postId = id.Value;
                    postDetail.ParticipantId = Convert.ToInt32(userId);
                    //LINQ
                    
                    var userControl = _context.PostDetail.Where(x=> x.ParticipantId == Convert.ToInt32(userId) && x.postId==id.Value).FirstOrDefault();
                    if(userControl != null)
                    {
                        Console.WriteLine("daha önce böyle bir kayıt var");
                    }
                    else
                    {
                        foreach (var item in _context.Posts)
                        {
                            if (item.PostId == id)
                            {
                                if (item.NumberOfParticipants != 0)
                                {
                                    item.NumberOfParticipants--;

                                }
           
                            }
                        }
                        Console.WriteLine("daha önce böyle bir kayıt yok");
                        
                        _context.Add(postDetail);

                    }
                    await _context.SaveChangesAsync();
                }catch(Exception ex)
                {
                    Console.WriteLine("Exception: " + ex);
                    return RedirectToAction("ListPost");

                }
            }
            return RedirectToAction("ListPost");
        }

        // GET: Post/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var postDetail = _context.PostDetail.ToList();
            List<User> userList = _context.Users.ToList();
            List<String> usernameList = new List<String>();

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

        public async Task<IActionResult> DeleteDetail(int? id)
        {
            if (id == null || _context.PostDetail == null)
            {
                return NotFound();
            }

            var post = await _context.PostDetail
                .Where(m => m.ParticipantId == id).FirstOrDefaultAsync();
            _context.PostDetail.Remove(post);
            await _context.SaveChangesAsync();
            if (post == null)
            {
                return NotFound();
            }

            return RedirectToAction("ListPost");
        }



        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.PostId == id);
        }



    }
}
