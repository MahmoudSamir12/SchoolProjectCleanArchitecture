using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configurations
{
    internal sealed class SchoolEventConfiguration : IEntityTypeConfiguration<SchoolEvent>
    {
        public void Configure(EntityTypeBuilder<SchoolEvent> entity)
        {
            entity.HasKey(se => se.Id);
            entity.Property(se => se.Title).IsRequired().HasMaxLength(150);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.EventDate).IsRequired();
        }

    }
}
