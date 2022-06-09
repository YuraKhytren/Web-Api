namespace Task12NetCoreBackEnd.Services
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetAllAsync(int type);
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T model);
        Task<T> UpdateAsync(T model);
        Task<bool> DeleteAsync(int id);
    }
}
