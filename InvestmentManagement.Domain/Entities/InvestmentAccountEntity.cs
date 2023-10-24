using System;

namespace InvestmentManagement.Domain.Entities
{
    public class InvestmentAccountEntity : BaseEntity
    {
        public InvestmentAccountEntity(int userId, decimal balance)
        {
            UserId = userId;
            Balance = balance;
            CreatedAt = DateTime.Now;

            Assets = new List<AssetEntity>();
            Operations = new List<OperationEntity>();
            Portfolios = new List<PortfolioEntity>();
        }

        public int UserId { get; private set; }
        public UserEntity User { get; private set; }
        public decimal Balance { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public List<AssetEntity> Assets { get; private set; }
        public List<OperationEntity> Operations { get; private set; }
        public List<PortfolioEntity> Portfolios { get; private set; }
    }
}
