using InvestmentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InvestmentManagement.Infrastructure.Configurations
{
    public class InvestmentAccountConfiguration : IEntityTypeConfiguration<InvestmentAccountEntity>
    {
        public void Configure(EntityTypeBuilder<InvestmentAccountEntity> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasMany(ia => ia.Portfolios)
                .WithOne(p => p.Account)
                .HasForeignKey(p => p.InvestmentAccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
