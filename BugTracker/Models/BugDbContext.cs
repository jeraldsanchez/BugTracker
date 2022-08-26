using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BugTracker.Models
{
    public class BugDbContext:DbContext
    {
        public BugDbContext(DbContextOptions<BugDbContext> options) : base(options)
        { }
            
        public DbSet<Bug> Bugs { get; set; }
    }
}
 