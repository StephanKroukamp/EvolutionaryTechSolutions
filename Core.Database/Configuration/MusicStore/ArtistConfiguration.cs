using Core.Entity.MusicStore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Database.Configuration.MusicStore
{
    internal class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        private const string TableName = "artist";

        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder
                .ToTable(TableName);

            builder
                .HasKey(artist => artist.Id);

            builder
                .Property(artist => artist.Id)
                .UseMySqlIdentityColumn();

            builder
                .Property(artist => artist.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(artist => artist.CoverArt)
                .IsRequired();
        }
    }
}