using Microsoft.EntityFrameworkCore;
using Task12NetCoreBackEnd.Models;

namespace Task12NetCoreBackEnd.DataBase
{
    public class AppDbContext : DbContext
    {
        public DbSet<FinanceType> FinanceTypes { get; set; }
        public DbSet<MoneyOperation> MoneyOperations { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)

        {
            
        }



    }
}
