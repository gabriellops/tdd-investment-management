using InvestmentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentManagement.Infrastructure.Configurations
{
    public class AssetConfiguration : IEntityTypeConfiguration<AssetEntity>
    {
        public void Configure(EntityTypeBuilder<AssetEntity> builder)
        {
            builder
                .HasKey(p => p.Id);
        }
    }
}
