namespace InvestmentManagement.Domain.Contracts.Requests
{
    public class UserRequest
    {
        public string CompanyName { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}