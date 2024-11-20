namespace FarmaControlAPI.Repository
{
    public interface IInventorioMovimientoRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
