using InvestmentManagement.Domain.Entities;
using InvestmentManagement.Domain.Interfaces.Repositories;
using InvestmentManagement.Domain.Interfaces.Services;

namespace InvestmentManagement.Domain.Services
{
    public class AssetService : BaseService<AssetEntity>, IAssetService
    {
        public AssetService(IBaseRepository<AssetEntity> baseRepository) : base(baseRepository)
        {
        }
    }
}
