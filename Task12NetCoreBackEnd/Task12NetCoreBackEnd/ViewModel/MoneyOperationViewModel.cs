using Task12NetCoreBackEnd.Models;

namespace Task12NetCoreBackEnd.ViewModel
{
    public class MoneyOperationViewModel : BaseModel
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Money { get; set; }

    }
}
