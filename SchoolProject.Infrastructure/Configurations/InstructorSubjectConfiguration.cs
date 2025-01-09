using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configurations
{
    internal sealed class InstructorSubjectConfiguration : IEntityTypeConfiguration<InstructorSubject>
    {
        public void Configure(EntityTypeBuilder<InstructorSubject> entity)
        {
            entity.HasKey(st => new { st.SubjectId, st.InstructorId });

            entity.HasOne(st => st.Instructor)
                  .WithMany(t => t.InstructorSubjects)
                  .HasForeignKey(st => st.InstructorId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(st => st.Subject)
                  .WithMany(s => s.InstructorSubjects)
                  .HasForeignKey(st => st.SubjectId)
                  .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
