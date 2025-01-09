using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configurations
{
    internal sealed class AssessmentConfiguration : IEntityTypeConfiguration<Assessment>
    {
        public void Configure(EntityTypeBuilder<Assessment> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Title).IsRequired().HasMaxLength(150);
            builder.Property(a => a.Description).HasMaxLength(500);
            builder.Property(e => e.DueDate).IsRequired();
            builder.HasOne(a => a.Subject)
                  .WithMany(s => s.Assessments)
                  .HasForeignKey(a => a.SubjectId)
                  .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
