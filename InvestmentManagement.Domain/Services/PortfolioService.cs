using InvestmentManagement.Domain.Entities;
using InvestmentManagement.Domain.Interfaces.Repositories;
using InvestmentManagement.Domain.Interfaces.Services;

namespace InvestmentManagement.Domain.Services
{
    public class PortfolioService : BaseService<PortfolioEntity>, IPortfolioService
    {
        public PortfolioService(IBaseRepository<PortfolioEntity> baseRepository) : base(baseRepository)
        {
        }
    }
}
