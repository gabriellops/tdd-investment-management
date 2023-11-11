using InvestmentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentManagement.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasMany(u => u.InvestmentAccounts)
                .WithOne(ia => ia.User)
                .HasForeignKey(ia => ia.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
