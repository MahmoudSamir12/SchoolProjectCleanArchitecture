using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configurations
{
    internal sealed class ExtraCurricalActivityConfiguration : IEntityTypeConfiguration<ExtraCurricularActivity>
    {
        public void Configure(EntityTypeBuilder<ExtraCurricularActivity> entity)
        {
            entity.HasKey(eca => eca.Id);
            entity.Property(eca => eca.Name).IsRequired();
            entity.Property(e => e.Description).HasMaxLength(500);
        }

    }
}
