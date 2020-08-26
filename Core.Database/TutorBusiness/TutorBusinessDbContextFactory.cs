using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Core.Database.TutorBusiness
{
    public class TutorBusinessDbContextFactory : IDesignTimeDbContextFactory<TutorBusinessDbContext>
    {
        public TutorBusinessDbContextFactory()
        {

        }

        public TutorBusinessDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../Core.Api/appsettings.tutorbusiness.json")
                .Build();

            var builder = new DbContextOptionsBuilder<TutorBusinessDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseMySql(connectionString);

            return new TutorBusinessDbContext(builder.Options);
        }
    }
}