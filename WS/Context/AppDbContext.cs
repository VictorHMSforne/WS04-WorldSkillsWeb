using Microsoft.EntityFrameworkCore;
using WS.Models;

namespace WS.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Pressao> pressao { get; set; }
    }
}
