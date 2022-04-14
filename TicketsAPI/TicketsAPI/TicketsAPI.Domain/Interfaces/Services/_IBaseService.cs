 using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketsAPI.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : IBaseModel
    {
        Task<T> FindAsync(long id);
        Task<IList<T>> ListAsync(IFilter filter = null);
        Task<long> InsertAsync(T model, long userId);
        Task<long> UpdateAsync(T model, long userId);
        Task DeleteAsync(long id);
    }
}
