using Task12NetCoreBackEnd.Models;

namespace Task12NetCoreBackEnd.Services.Interface
{
    public interface IReport
    {
        Task<Report> GetByDateAsync(DateTime date);
        Task<Report> GetBetweenDatesAsync(DateTime startDate, DateTime endDate);
    }
}
