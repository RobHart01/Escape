using Microsoft.EntityFrameworkCore;
 
namespace Escape.Models
{
    public class EscapeContext : DbContext
    {
        public EscapeContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}
