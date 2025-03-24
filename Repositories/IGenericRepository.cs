using System.Collections.Generic;
using System.Threading.Tasks;
using bai_tap_Advance.Properties.Models;

namespace bai_tap_Advance.Properties.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
