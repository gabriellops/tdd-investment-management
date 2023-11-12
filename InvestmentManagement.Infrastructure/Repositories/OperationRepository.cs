using InvestmentManagement.Domain.Entities;
using InvestmentManagement.Domain.Interfaces.Repositories;
using InvestmentManagement.Infrastructure.Contexts;

namespace InvestmentManagement.Infrastructure.Repositories
{
    public class OperationRepository : BaseRepository<OperationEntity>, IOperationRepository
    {
        public OperationRepository(InvestmentContext context) : base(context)
        {
        }
    }
}
