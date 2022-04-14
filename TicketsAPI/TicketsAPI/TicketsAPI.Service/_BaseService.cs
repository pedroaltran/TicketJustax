using System.Collections.Generic;
using System.Threading.Tasks;
using TicketsAPI.Domain;
using TicketsAPI.Domain.Interfaces;
using TicketsAPI.Domain.Interfaces.Repos.ReadOnly;
using TicketsAPI.Domain.Interfaces.Repos.Writable;
using TicketsAPI.Domain.Interfaces.Services;

namespace TicketsAPI.Service
{
    public class BaseService<T> : IBaseService<T> where T : BaseModel, IBaseModel
    {
        private readonly IBaseRepo<T> _repo;
        private readonly IBaseRepoReadOnly<T> _repoReadOnly;

        public BaseService(IBaseRepo<T> repo, IBaseRepoReadOnly<T> repoReadOnly)
        {
            _repo = repo;
            _repoReadOnly = repoReadOnly;
        }

        public virtual async Task DeleteAsync(long id) => await _repo.DeleteAsync(await FindAsync(id));

        public virtual async Task<T> FindAsync(long id) => await _repoReadOnly.FindAsync(id);

        public virtual async Task<long> InsertAsync(T model, long userId) => await _repo.InsertAsync(model);

        public virtual async Task<IList<T>> ListAsync(IFilter filter = null) => await _repoReadOnly.ListAsync(filter);

        public virtual async Task<long> UpdateAsync(T model, long userId) => await _repo.UpdateAsync(model);
    }
}
