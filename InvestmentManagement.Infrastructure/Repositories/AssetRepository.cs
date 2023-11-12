using InvestmentManagement.Domain.Entities;
using InvestmentManagement.Domain.Interfaces.Repositories;
using InvestmentManagement.Infrastructure.Contexts;

namespace InvestmentManagement.Infrastructure.Repositories
{
    public class AssetRepository : BaseRepository<AssetEntity>, IAssetRepository
    {
        public AssetRepository(InvestmentContext context) : base(context)
        {
        }
    }
}
