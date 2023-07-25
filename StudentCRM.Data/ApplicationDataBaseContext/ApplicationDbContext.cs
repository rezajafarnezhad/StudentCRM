using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentCRM.Data.Entities;

namespace StudentCRM.Data.ApplicationDataBaseContext
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser,IdentityRole,string> , IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> op):base(op) { }


        public DbSet<StudentResult> StudentResults { get; set; }
        public DbSet<Term> Terms{ get; set; }
        public DbSet<Course> Course{ get; set; }
        public DbSet<Student> Students{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserLogin<string>>().HasKey(c => new { c.ProviderKey, c.LoginProvider });
            builder.Entity<IdentityUserRole<string>>().HasKey(c => new { c.UserId, c.RoleId });
            builder.Entity<IdentityUserToken<string>>().HasKey(c => new { c.UserId, c.Name,c.LoginProvider });

        }
    }
}