namespace Task12NetCoreBackEnd.Models
{
    public class Report
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalOutcome { get; set; }
        public List<MoneyOperation> Operations { get; set; }
    }
}
