using Core.Auth;
using Core.Database.Configuration.TutorBusiness;
using Core.Entity.TutorBusiness;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Core.Database.TutorBusiness
{
    public class TutorBusinessDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public TutorBusinessDbContext(DbContextOptions<TutorBusinessDbContext> options) : base(options)
        {

        }

        public DbSet<Parent> Parents { get; set; }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Auth
            modelBuilder.Entity<ApplicationRole>().ToTable("application_role");
            modelBuilder.Entity<ApplicationUser>().ToTable("application_user");
            modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("application_role_claim");
            modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("application_user_claim");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("application_user_role");
            modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("application_user_login");
            modelBuilder.Entity<IdentityUserToken<int>>().ToTable("application_user_token");

            // Tutor Business
            modelBuilder.ApplyConfiguration(new ParentConfiguration());

            modelBuilder.ApplyConfiguration(new StudentConfiguration());
        }
    }
}