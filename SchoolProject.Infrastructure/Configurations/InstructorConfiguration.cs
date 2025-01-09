using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configurations
{
    internal sealed class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> entity)
        {
            entity.HasBaseType<Staff>(); // Inherits properties from Staff
            entity.Property(t => t.Subject).HasMaxLength(50);
            entity.Property(e => e.HireDate).IsRequired();

        }

    }
}
