using Microsoft.EntityFrameworkCore;
using ProjeKamp.Models;

namespace ProjeKamp.Context
{
    public class CampDataContext : DbContext
    {

        public CampDataContext(DbContextOptions<CampDataContext> options)
            : base(options)
        { 
 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<PostDetail> PostDetail { get; set; }


    }
}
