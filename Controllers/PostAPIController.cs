using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjeKamp.Context;
using ProjeKamp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjeKamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostAPIController : ControllerBase
    {
        private readonly CampDataContext _context;

        public PostAPIController(CampDataContext context)
        {
            _context = context;
        }

        // GET: api/<PostAPIController>
        [HttpGet]
        public async Task<ActionResult<List<Post>>> Get()
        {
            var postList = await _context.Posts.ToListAsync();
            if(postList is null)
            {
                return NoContent();

            }
            return postList;
        }

       
    }
}
