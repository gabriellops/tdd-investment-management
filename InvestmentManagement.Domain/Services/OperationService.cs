using InvestmentManagement.Domain.Entities;
using InvestmentManagement.Domain.Interfaces.Repositories;
using InvestmentManagement.Domain.Interfaces.Services;

namespace InvestmentManagement.Domain.Services
{
    public class OperationService : BaseService<OperationEntity>, IOperationService
    {
        public OperationService(IBaseRepository<OperationEntity> baseRepository) : base(baseRepository)
        {
        }
    }
}
