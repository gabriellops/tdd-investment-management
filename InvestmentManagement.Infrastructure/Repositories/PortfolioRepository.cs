using InvestmentManagement.Domain.Entities;
using InvestmentManagement.Domain.Interfaces.Repositories;
using InvestmentManagement.Infrastructure.Contexts;

namespace InvestmentManagement.Infrastructure.Repositories
{
    public class PortfolioRepository : BaseRepository<PortfolioEntity>, IPortfolioRepository
    {
        public PortfolioRepository(InvestmentContext context) : base(context)
        {
        }
    }
}
