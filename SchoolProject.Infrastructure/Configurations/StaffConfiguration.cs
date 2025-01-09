using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configurations
{
    internal sealed class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> entity)
        {
            entity.HasKey(s => s.Id);
            entity.Property(s => s.NameEn).IsRequired().HasMaxLength(100);
            entity.Property(s => s.NameAr).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Position).HasMaxLength(100);
            entity.Property(s => s.Salary).HasPrecision(18, 2);
            entity.HasOne(x => x.Supervisor)
                 .WithMany(s => s.Staffs)
                 .HasForeignKey(d => d.SupervisorId)
                 .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
