namespace InvestmentManagement.Domain.Contracts.Responses
{
    public class AuthenticateResponse
    {
        public string Token { get; set; }
        public DateTime? DataExpiracao { get; set; }
    }
}
