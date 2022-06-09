using Microsoft.EntityFrameworkCore;
using Task12NetCoreBackEnd.DataBase;
using Task12NetCoreBackEnd.Models;

namespace Task12NetCoreBackEnd.Services
{
    public class FinanceTypeService : IService<FinanceType>
    {
        private readonly AppDbContext _db;
        public FinanceTypeService(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            FinanceType model = await _db.FinanceTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (model != null)
            {
                _db.FinanceTypes.Remove(model);
                await _db.SaveChangesAsync();

            }

            return true;

        }

        public async Task<IEnumerable<FinanceType>> GetAllAsync(int type)
        {
            if (type == 1)
            {
                await _db.FinanceTypes.Where(c => c.Income == true).ToListAsync();
            }
            else if (type == 2)
            {
                await _db.FinanceTypes.Where(c => c.Income == false).ToListAsync();
            }

            return await _db.FinanceTypes.ToListAsync();
        }

        public async Task<FinanceType> GetByIdAsync(int id)
        {
            FinanceType model = await _db.FinanceTypes.FirstOrDefaultAsync(x => x.Id == id);
            return model;
        }

        public async Task<FinanceType> CreateAsync(FinanceType model)
        {
            _db.FinanceTypes.Add(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<FinanceType> UpdateAsync(FinanceType model)
        {
            _db.FinanceTypes.Update(model);
            await _db.SaveChangesAsync();
            return model;
        }
    }
}
