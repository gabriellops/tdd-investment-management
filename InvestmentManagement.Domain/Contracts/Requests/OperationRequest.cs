namespace InvestmentManagement.Domain.Contracts.Requests
{
    public class OperationRequest
    {
        public string Type { get; set; }
        public decimal Price { get; set; }

        public int PortfolioId { get; set; }
        public int AssetId { get; set; }
    }
}