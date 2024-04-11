using InvestmentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentManagement.Infrastructure.Configurations
{
    public class OperationConfiguration : IEntityTypeConfiguration<OperationEntity>
    {
        public void Configure(EntityTypeBuilder<OperationEntity> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasOne(o => o.Asset)
                .WithMany()
                .HasForeignKey(o => o.AssetId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(o => o.Portfolio)
                .WithMany()
                .HasForeignKey(o => o.PortfolioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
