using Core.Database.Configuration.TutorBusiness;
using Core.Entity.TutorBusiness;
using Microsoft.EntityFrameworkCore;

namespace Core.Database.TutorBusiness
{
    public class TutorBusinessDbContext : DbContext
    {
        public TutorBusinessDbContext(DbContextOptions<TutorBusinessDbContext> options) : base(options)
        {

        }

        public DbSet<Parent> Parents { get; set; }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ParentConfiguration());

            modelBuilder.ApplyConfiguration(new StudentConfiguration());
        }
    }
}