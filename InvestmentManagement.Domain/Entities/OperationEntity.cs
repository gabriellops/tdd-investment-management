namespace InvestmentManagement.Domain.Entities
{
    public class OperationEntity : BaseEntity
    {
        public OperationEntity() { }

        public OperationEntity(int accountId, int assetId, string type, decimal price)
        {
            AccountId = accountId;
            AssetId = assetId;
            Type = type;
            Price = price;
            CreatedAt = DateTime.Now;
        }

        public int AccountId { get; private set; }
        public InvestmentAccountEntity Account { get; private set; }
        public int AssetId { get; private set; }
        public AssetEntity Asset { get; private set; }
        public string Type { get; private set; }
        public decimal  Price { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
    }
}
