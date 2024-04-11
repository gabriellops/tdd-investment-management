using InvestmentManagement.Domain.Enums;

namespace InvestmentManagement.Domain.Entities
{
    public class AssetEntity : BaseEntity
    {
        public AssetEntity(string name, string code, EAssetTypeEnum type, decimal buyPrice, DateTime createdAt)
        {
            Name = name;
            Code = code;
            Type = type;
            BuyPrice = buyPrice;

            CreatedAt = createdAt;
        }

        public string Name { get; private set; }
        public string Code { get; private set; }
        public EAssetTypeEnum Type { get; private set; }
        public int Quantity { get; private set; }
        public decimal BuyPrice { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
    }
}
