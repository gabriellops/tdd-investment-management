using InvestmentManagement.Domain.Enums;

namespace InvestmentManagement.Domain.Entities
{
    public class OperationEntity : BaseEntity
    {
        public OperationEntity() { }

        public OperationEntity(int portfolioId, int assetId, string type, decimal price)
        {
            portfolioId = portfolioId;
            AssetId = assetId;
            Type = type;
            Price = price;
            CreatedAt = DateTime.Now;
        }

        public string Type { get; private set; }
        public decimal  Price { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }


        public int PortfolioId { get; private set; }
        public PortfolioEntity Portfolio { get; private set; }
        public int AssetId { get; private set; }
        public AssetEntity Asset { get; private set; }
    }
}
