using Microsoft.EntityFrameworkCore;
using Task12NetCoreBackEnd.DataBase;
using Task12NetCoreBackEnd.Models;
using Task12NetCoreBackEnd.Services.Interface;

namespace Task12NetCoreBackEnd.Services
{
    public class ReportService : IReport
    {
        private readonly AppDbContext _db;
        public ReportService(AppDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<Report> GetBetweenDatesAsync(DateTime startDate, DateTime endDate)
        {
            List<MoneyOperation> monthOperation = await _db.MoneyOperations.Where(o => o.Date >= startDate && o.Date <= endDate).ToListAsync();

            Report monthReport = new Report()
            {
                Operations = monthOperation,
                TotalIncome = monthOperation.Where(d => d.FinanceType.Income == true).Sum(o => o.Money),
                TotalOutcome = monthOperation.Where(d => d.FinanceType.Income == false).Sum(o => o.Money),
            };


            return monthReport;
        }

        public async Task<Report> GetByDateAsync(DateTime date)
        {
            List<MoneyOperation> dayOperations = await _db.MoneyOperations.Where(o => o.Date == date).ToListAsync();

            Report dayReport = new Report()
            {
                Operations = dayOperations,
                TotalIncome = dayOperations.Where(d => d.FinanceType.Income == true).Sum(o => o.Money),
                TotalOutcome = dayOperations.Where(d => d.FinanceType.Income == false).Sum(o => o.Money),
            };


            return dayReport;
        }
    }
}
