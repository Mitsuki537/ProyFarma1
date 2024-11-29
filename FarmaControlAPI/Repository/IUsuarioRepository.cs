namespace FarmaControlAPI.Repository
{
    public interface IUsuarioRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> EmployeeExistAsync(int idEmployee);
        Task<T> GetByUsernameAsync(string username);
    }
}
