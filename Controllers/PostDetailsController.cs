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
    public class PostDetailsController : Controller
    {
        private readonly CampDataContext _context;

        public PostDetailsController(CampDataContext context)
        {
            _context = context;
        }

        // GET: PostDetails
        public async Task<IActionResult> Index()
        {
              return View(await _context.PostDetail.ToListAsync());
        }

        // GET: PostDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PostDetail == null)
            {
                return NotFound();
            }

            var postDetail = await _context.PostDetail
                .FirstOrDefaultAsync(m => m.postId == id);
            if (postDetail == null)
            {
                return NotFound();
            }

            return View(postDetail);
        }

        // GET: PostDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("postId,ParticipantId")] PostDetail postDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postDetail);
        }

        // GET: PostDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PostDetail == null)
            {
                return NotFound();
            }

            var postDetail = await _context.PostDetail.FindAsync(id);
            if (postDetail == null)
            {
                return NotFound();
            }
            return View(postDetail);
        }

        // POST: PostDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("postId,ParticipantId")] PostDetail postDetail)
        {
            if (id != postDetail.postId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostDetailExists(postDetail.postId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(postDetail);
        }

        // GET: PostDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PostDetail == null)
            {
                return NotFound();
            }

            var postDetail = await _context.PostDetail
                .FirstOrDefaultAsync(m => m.postId == id);
            if (postDetail == null)
            {
                return NotFound();
            }

            return View(postDetail);
        }

        // POST: PostDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PostDetail == null)
            {
                return Problem("Entity set 'CampDataContext.PostDetail'  is null.");
            }
            var postDetail = await _context.PostDetail.FindAsync(id);
            if (postDetail != null)
            {
                _context.PostDetail.Remove(postDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostDetailExists(int id)
        {
          return _context.PostDetail.Any(e => e.postId == id);
        }
    }
}
