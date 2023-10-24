namespace InvestmentManagement.Domain.Entities
{
    public class PortfolioEntity : BaseEntity
    {
        public PortfolioEntity(int investmentAccountId)
        {
            InvestmentAccountId = investmentAccountId;
            CreatedAt = DateTime.Now;

            Operations = new List<OperationEntity>();
        }

        public int InvestmentAccountId { get; private set; }
        public InvestmentAccountEntity Account { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public List<OperationEntity> Operations { get; private set; }
    }
}
