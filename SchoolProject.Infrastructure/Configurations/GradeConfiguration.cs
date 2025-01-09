using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configurations
{
    internal sealed class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> entity)
        {
            //entity.HasKey(g => g.Id);
            entity.HasKey(g => new { g.SubjectId, g.StudentId }); // Composite key for Grade
            //entity.Property(e => e.Score).IsRequired().HasRange(0, 100);
            entity.Property(e => e.Score)
                    .IsRequired()
                    .HasColumnType("decimal(5, 2)"); // Changed precision and scale

            // Configure the table, adding the check constraint here
            entity.ToTable("Grades", t => t.HasCheckConstraint("CHK_Score", "Score >= 0 AND Score <= 100"));

            entity.Property(l => l.LetterGrade).HasMaxLength(100);

            entity.HasOne(g => g.Enrollment)
                  .WithMany(e => e.Grades)
                  .HasForeignKey(g => new { g.SubjectId, g.StudentId }) // Composite foreign key configuration
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(g => g.Assessment)
                  .WithMany(a => a.Grades)
                  .HasForeignKey(g => g.AssessmentId)
                  .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
