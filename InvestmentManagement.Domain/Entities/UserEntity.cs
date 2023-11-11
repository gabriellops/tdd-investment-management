using System;

namespace InvestmentManagement.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public UserEntity(string companyName, string cnpj, string email, string password, bool active)
        {
            CompanyName = companyName;
            Cnpj = cnpj;
            Email = email;
            Password = password;
            Active = active;
            CreatedAt = DateTime.Now;

            InvestmentAccounts = new List<InvestmentAccountEntity>();
        }

        public string CompanyName { get; private set; }
        public string Cnpj { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; private set; }

        public ICollection<InvestmentAccountEntity> InvestmentAccounts { get; private set; }
    }
}
