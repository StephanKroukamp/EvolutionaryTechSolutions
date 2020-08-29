using Core.Auth;
using Core.Database.Configuration.TutorBusiness;
using Core.Entity.TutorBusiness;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Core.Database.TutorBusiness
{
    public class TutorBusinessDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public TutorBusinessDbContext(DbContextOptions<TutorBusinessDbContext> options) : base(options)
        {

        }

        public DbSet<Parent> Parents { get; set; }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole<int>>().ToTable("identity_role");
            modelBuilder.Entity<ApplicationUser>().ToTable("identity_user");
            modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("identity_role_claim");
            modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("identity_user_claim");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("identity_user_role");
            modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("identity_user_login");
            modelBuilder.Entity<IdentityUserToken<int>>().ToTable("identity_user_token");

            modelBuilder.ApplyConfiguration(new ParentConfiguration());

            modelBuilder.ApplyConfiguration(new StudentConfiguration());
        }
    }
}