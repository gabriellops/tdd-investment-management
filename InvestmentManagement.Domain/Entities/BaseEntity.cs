namespace InvestmentManagement.Domain.Entities
{
    public class BaseEntity
    {
        protected BaseEntity() 
        {
            Active = true;
        }

        public int Id { get; private set; }
        public bool Active { get; set; }
    }
}