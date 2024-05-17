using LTrinhWebNhom3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LTrinhWebNhom3.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> applicationUsers { get; set; }
  
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<PortfolioImage> PortfolioImages { get; set; }
        public DbSet<Project> Projects { get; set; }
     
  
        



    }
}
