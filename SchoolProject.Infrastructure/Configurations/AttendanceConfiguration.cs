using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configurations
{
    internal sealed class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            //builder.HasKey(a => a.Id);
            builder.HasKey(a => new { a.EnrollmentId, a.SubjectId, a.StudentId });
            builder.Property(e => e.Date).IsRequired();
            builder.HasOne(a => a.Enrollment)
                  .WithMany(e => e.Attendances)
                  //.HasForeignKey(a => a.EnrollmentId)
                  .HasForeignKey(a => new { a.SubjectId, a.StudentId })
                  .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
