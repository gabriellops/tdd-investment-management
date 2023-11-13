namespace InvestmentManagement.Domain.Contracts.Responses
{
    public class OperationResponse : BaseResponse
    {
        public string Type { get; set; }
        public decimal Price { get; set; }

        public PortfolioResponse Portfolio { get; set; }
        public AssetResponse Asset { get; set; }
    }
}