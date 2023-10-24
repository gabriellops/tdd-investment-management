namespace InvestmentManagement.Domain.Entities
{
    public class AssetEntity : BaseEntity
    {
        public AssetEntity(string name, string code, string type, decimal currentPrice)
        {
            Name = name;
            Code = code;
            Type = type;
            CurrentPrice = currentPrice;
            UpdatedAt = DateTime.Now;
        }

        public string Name { get; private set; }
        public string Code { get; private set; }
        public string Type { get; private set; }
        public decimal CurrentPrice { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
    }
}
