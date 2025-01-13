using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configurations
{
    internal sealed class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            //builder.ToTable(nameof(Student));
            builder.HasKey(s => s.Id);
            builder.Property(s => s.NameEn).IsRequired().HasMaxLength(100);
            builder.Property(s => s.NameAr).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Email).HasMaxLength(200);
            builder.Property(s => s.Address).HasMaxLength(500);
            builder.Property(s => s.Phone).HasMaxLength(15);
            builder.HasOne(s => s.Department)
                  .WithMany(d => d.Students)
                  .HasForeignKey(s => s.DepartmentId)
                  .OnDelete(DeleteBehavior.Restrict);


        }

    }
}
