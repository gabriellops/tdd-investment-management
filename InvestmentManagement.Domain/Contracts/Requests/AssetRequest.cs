using InvestmentManagement.Domain.Enums;

namespace InvestmentManagement.Domain.Contracts.Requests
{
    public class AssetRequest
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public EAssetTypeEnum Type { get; set; }
        public int Quantity { get; set; }
        public decimal BuyPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}