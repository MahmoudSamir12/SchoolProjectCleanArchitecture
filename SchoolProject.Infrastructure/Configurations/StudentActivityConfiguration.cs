using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configurations
{
    internal sealed class StudentActivityConfiguration : IEntityTypeConfiguration<StudentActivity>
    {
        public void Configure(EntityTypeBuilder<StudentActivity> entity)
        {
            entity.HasKey(sa => sa.Id);
            entity.HasOne(sa => sa.Student)
                  .WithMany(s => s.StudentActivities)
                  .HasForeignKey(sa => sa.StudentId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(sa => sa.ExtraCurricularActivity)
                  .WithMany(eca => eca.StudentActivities)
                  .HasForeignKey(sa => sa.ExtraCurricularActivityId)
                  .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
