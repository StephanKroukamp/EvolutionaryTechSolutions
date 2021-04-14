using Core.Auth;
using Core.Database.Configuration.MusicStore;
using Core.Entity.MusicStore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Core.Database.MusicStore
{
    public class MusicStoreDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public MusicStoreDbContext(DbContextOptions<MusicStoreDbContext> options) : base(options)
        {

        }

        public DbSet<Artist> Artists { get; set; }


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

            // Music Store
            modelBuilder.ApplyConfiguration(new ArtistConfiguration());
        }
    }
}