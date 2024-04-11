
namespace InvestmentManagement.Domain.Contracts.Responses
{
    public class PortfolioResponse : BaseResponse
    {
        public InvestmentAccountResponse InvestmentAccount { get; set; }
    }
}