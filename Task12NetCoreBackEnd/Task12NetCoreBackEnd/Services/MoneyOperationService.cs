using Microsoft.EntityFrameworkCore;
using Task12NetCoreBackEnd.DataBase;
using Task12NetCoreBackEnd.Models;

namespace Task12NetCoreBackEnd.Services
{
    public class MoneyOperationService : IService<MoneyOperation>
    {
       private readonly AppDbContext _db;
        public MoneyOperationService(AppDbContext dbContext) 
        {
            _db = dbContext;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            MoneyOperation model = await _db.MoneyOperations.FirstOrDefaultAsync(m => m.Id == id);

            if (model != null)
            {
            _db.MoneyOperations.Remove(model);
            await _db.SaveChangesAsync();
            }

            return true;
           
        }

        public async Task<IEnumerable<MoneyOperation>> GetAllAsync(int type)
        {
            
            return await _db.MoneyOperations.OrderBy(s => s.Date).ToListAsync();
        }

        public async Task<MoneyOperation> GetByIdAsync(int id)
        {
            return await _db.MoneyOperations.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<MoneyOperation> CreateAsync(MoneyOperation model)
        {
            
            if (model.FinanceType.Income == true && model.Money < 0)
            {
                throw new ArgumentException();
            }

            _db.MoneyOperations.Add(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<MoneyOperation> UpdateAsync(MoneyOperation model)
        {
            _db.MoneyOperations.Update(model);
            await _db.SaveChangesAsync();

            return model;

        }
    }
}
