using System.Threading.Tasks;

namespace TicketsAPI.Domain.Interfaces.Repos.Writable
{
    public interface IBaseRepo<T> where T : IBaseModel
    {
        Task<long> InsertAsync(T model);
        Task<long> UpdateAsync(T model);
        Task DeleteAsync(T model);
    }
}
