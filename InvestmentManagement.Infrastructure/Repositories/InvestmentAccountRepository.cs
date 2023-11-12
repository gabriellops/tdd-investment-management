using InvestmentManagement.Domain.Entities;
using InvestmentManagement.Domain.Interfaces.Repositories;
using InvestmentManagement.Infrastructure.Contexts;

namespace InvestmentManagement.Infrastructure.Repositories
{
    public class InvestmentAccountRepository : BaseRepository<InvestmentAccountEntity>, IInvestmentAccountRepository
    {
        public InvestmentAccountRepository(InvestmentContext context) : base(context)
        {
        }
    }
}
