namespace InvestmentManagement.Domain.Contracts.Responses
{
    public class UserResponse : BaseResponse
    {
        public string CompanyName { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
    }
}