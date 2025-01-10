using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configurations
{
    internal sealed class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> entity)
        {
            entity.HasOne(i => i.Supervisor)
                    .WithMany(i => i.Instructors)
                    .HasForeignKey(i => i.SupervisorId)
                    .OnDelete(DeleteBehavior.Restrict); // Adjusting cascade behavior

            entity.HasOne(i => i.department)
                    .WithMany(d => d.Instructors)
                    .HasForeignKey(i => i.DepartmentId)
                    .OnDelete(DeleteBehavior.Restrict); // Adjusting cascade behavior

            entity.Property(i => i.Salary)
                    .HasColumnType("decimal(18,2)"); // Alternatively, .HasPrecision(18, 2);

        }

    }
}
