using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configurations
{
    internal sealed class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> entity)
        {
            entity.HasKey(s => s.Id);
            entity.Property(s => s.SubjectNameEn).IsRequired().HasMaxLength(100);
            entity.Property(s => s.SubjectNameAr).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Period).IsRequired();
        }

    }
}
