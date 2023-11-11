using InvestmentManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestmentManagement.Infrastructure.Contexts
{
    public class InvestmentContext : DbContext
    {
        public InvestmentContext(DbContextOptions<InvestmentContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<InvestmentAccountEntity> InvestmentAccounts { get; set; }
        public DbSet<AssetEntity> Assets { get; set; }
        public DbSet<OperationEntity> Operations { get; set; }
        public DbSet<PortfolioEntity> Portfolios { get; set; }
    }
}
