namespace InvestmentManagement.Domain.Contracts.Responses
{
    public class InvestmentAccountResponse : BaseResponse
    {
        public decimal Balance { get; set; }

        public UserResponse User { get; set; }
    }
}