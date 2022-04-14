using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketsAPI.Data.Contexts;
using TicketsAPI.Domain;
using TicketsAPI.Domain.Interfaces;
using TicketsAPI.Domain.Interfaces.Repos.ReadOnly;

namespace TicketsAPI.Data.ReadOnly
{
    public class BaseRepoReadOnly<T> : IBaseRepoReadOnly<T> where T : BaseModel
    {
        private readonly DataReadOnlyContext _context;
        public BaseRepoReadOnly(DataReadOnlyContext context) => _context = context;

        public virtual async Task<T> FindAsync(long id) => await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

        public virtual async Task<IList<T>> ListAsync(IFilter filter = null) => await _context.Set<T>().ToListAsync();
    }
}
