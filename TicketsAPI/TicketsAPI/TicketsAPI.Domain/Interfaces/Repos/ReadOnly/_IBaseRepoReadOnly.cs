using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketsAPI.Domain.Interfaces.Repos.ReadOnly
{
    public interface IBaseRepoReadOnly<T> where T : IBaseModel
    {
        Task<T> FindAsync(long id);
        Task<IList<T>> ListAsync(IFilter filter = null);
    }
}
