using InvestmentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentManagement.Infrastructure.Configurations
{
    public class PortfolioConfiguration : IEntityTypeConfiguration<PortfolioEntity>
    {
        public void Configure(EntityTypeBuilder<PortfolioEntity> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasMany(p => p.Operations)
                .WithOne(o => o.Portfolio)
                .HasForeignKey(o => o.PortfolioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
