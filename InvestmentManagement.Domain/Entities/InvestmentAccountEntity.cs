using System;

namespace InvestmentManagement.Domain.Entities
{
    public class InvestmentAccountEntity : BaseEntity
    {
        public InvestmentAccountEntity(decimal balance, int userId)
        {
            Balance = balance;
            UserId = userId;

            CreatedAt = DateTime.Now;

            Portfolios = new List<PortfolioEntity>();
        }

        public decimal Balance { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public int UserId { get; private set; }
        public UserEntity User { get; private set; }

        public ICollection<PortfolioEntity> Portfolios { get; private set; }
    }
}
