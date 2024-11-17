namespace FarmaControlAPI.Repository
{
    public interface IInventorioMovimientoRepository<T>
    {
        Task<int> CreateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
