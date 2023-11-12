namespace InvestmentManagement.Domain.Contracts.Response
{
    public class AuthenticateResponse
    {
        public string Token { get; set; }
        public DateTime? DataExpiracao { get; set; }
    }
}
