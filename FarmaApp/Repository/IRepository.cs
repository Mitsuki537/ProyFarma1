using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaApp.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync(string? queryParams = null);
        Task<T> GetByIdAsync(int id);
        Task<int> CreateAsync(object dto);
        Task<bool> UpdateAsync(int id, object dto);
        Task<bool> DeleteAsync(int id);
    }
}
