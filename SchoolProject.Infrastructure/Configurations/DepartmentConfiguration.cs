using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configurations
{
    internal sealed class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> entity)
        {
            entity.HasKey(d => d.Id);
            entity.Property(d => d.DepartmentNameEn).IsRequired().HasMaxLength(100);
            entity.Property(d => d.DepartmentNameAr).IsRequired().HasMaxLength(100);
            entity.HasOne(x => x.Instructor)
                .WithOne(d => d.DepartmentManager)
                .HasForeignKey<Department>(x => x.InstManger)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(st => st.Students)
                    .WithOne(d => d.Department)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
