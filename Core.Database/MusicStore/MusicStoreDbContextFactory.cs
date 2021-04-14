using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Core.Database.MusicStore
{
    public class MusicStoreDbContextFactory : IDesignTimeDbContextFactory<MusicStoreDbContext>
    {
        public MusicStoreDbContextFactory()
        {

        }

        public MusicStoreDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../Core.Api/appsettings.musicstore.json")
                .Build();

            var builder = new DbContextOptionsBuilder<MusicStoreDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseMySql(connectionString);

            return new MusicStoreDbContext(builder.Options);
        }
    }
}