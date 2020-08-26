using Core.Entity.TutorBusiness;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Database.Configuration.TutorBusiness
{
    internal class ParentConfiguration : IEntityTypeConfiguration<Parent>
    {
        private const string TableName = "parents";

        public void Configure(EntityTypeBuilder<Parent> builder)
        {
            builder
                .ToTable(TableName);

            builder
                .HasKey(parent => parent.Id);

            builder
                .Property(parent => parent.Id)
                .UseMySqlIdentityColumn();

            builder
            .HasMany<Student>(g => g.Students)
            .WithOne(s => s.Parent)
            .HasForeignKey(s => s.ParentId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(parent => parent.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(parent => parent.LastName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}