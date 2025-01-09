using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configurations
{
    internal sealed class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> entity)
        {
            //entity.HasKey(s => s.Id);
            entity.HasKey(s => new { s.SubjectId, s.InstructorSubjectId });
            entity.Property(e => e.StartTime).IsRequired();
            entity.Property(e => e.EndTime).IsRequired();
            entity.Property(s => s.Location).IsRequired().HasMaxLength(250);
            entity.HasOne(s => s.InstructorSubject)
                  .WithMany(st => st.Schedules)
                  .HasForeignKey(s => new { s.SubjectId, s.InstructorSubjectId })
                  .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
