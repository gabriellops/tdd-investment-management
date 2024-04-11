namespace InvestmentManagement.Domain.Contracts.Requests
{
    public class InvestmentAccountRequest
    {
        public decimal Balance { get; set; }

        public int UserId { get; set; }

    }
}