using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParseTry.Main;

namespace webSkin.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<ResultItem> ResultItems { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
