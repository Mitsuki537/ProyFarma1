namespace FarmaControlAPI.Repository
{
    public interface IInventarioRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
