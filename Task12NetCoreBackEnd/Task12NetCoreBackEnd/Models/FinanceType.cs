namespace Task12NetCoreBackEnd.Models
{
    public class FinanceType : BaseModel
    {
        public string Name { get; set; }
        public bool Income { get; set; }
        public List<MoneyOperation> MoneyOperations { get; set; }
    }
}
