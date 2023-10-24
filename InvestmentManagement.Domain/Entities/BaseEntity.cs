namespace InvestmentManagement.Domain.Entities
{
    public class BaseEntity
    {
        protected BaseEntity() { }

        public int Id { get; private set; }
    }
}