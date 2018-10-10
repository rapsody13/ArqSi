using Microsoft.EntityFrameworkCore;

namespace ClosetApi.Models
{
    public class ClosetContext : DbContext
    {
        public ClosetContext(DbContextOptions<ClosetContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Material> Materials {get; set;}
        public DbSet<Finish> Finishes {get; set;}
        public DbSet<Category> Categories {get; set;}
       

    }
}