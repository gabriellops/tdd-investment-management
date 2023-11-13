namespace InvestmentManagement.Domain.Entities
{
    public class BaseEntity
    {
        protected BaseEntity() 
        {
            Active = true;
        }

        public int Id { get; set; }
        public bool Active { get; set; }
    }
}