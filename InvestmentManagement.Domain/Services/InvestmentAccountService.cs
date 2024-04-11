using InvestmentManagement.Domain.Entities;
using InvestmentManagement.Domain.Interfaces.Repositories;
using InvestmentManagement.Domain.Interfaces.Services;

namespace InvestmentManagement.Domain.Services
{
    public class InvestmentAccountService : BaseService<InvestmentAccountEntity>, IInvestmentAccountService
    {
        public InvestmentAccountService(IBaseRepository<InvestmentAccountEntity> baseRepository) : base(baseRepository)
        {
        }
    }
}
