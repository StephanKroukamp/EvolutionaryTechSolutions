using Core.Entity.TutorBusiness;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Database.Configuration.TutorBusiness
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        private const string TableName = "students";

        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .ToTable(TableName);

            builder
                .HasKey(student => student.Id);

            builder
                .Property(student => student.Id)
                .UseMySqlIdentityColumn();

            builder
                .HasOne(student => student.Parent)
                .WithMany(parent => parent.Students)
                .HasForeignKey(student => student.ParentId);

            builder
                .Property(student => student.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(student => student.LastName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}