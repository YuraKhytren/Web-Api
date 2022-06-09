namespace Task12NetCoreBackEnd.Models
{
    public class MoneyOperation : BaseModel
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int FinanceTypeId { get; set; }
        public FinanceType FinanceType { get; set; }
    }
}
