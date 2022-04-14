using System.Threading.Tasks;
using TicketsAPI.Data.Contexts;
using TicketsAPI.Domain;
using TicketsAPI.Domain.Interfaces.Repos.Writable;

namespace TicketsAPI.Data.Writable
{
    public class BaseRepo<T> : IBaseRepo<T> where T : BaseModel
    {
        private readonly DataContext _context;
        public BaseRepo(DataContext context) => _context = context;

        public virtual async Task DeleteAsync(T model)
        {
            _context.Set<T>().Remove(model);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<long> InsertAsync(T model)
        {
            _context.Set<T>().Add(model);
            await _context.SaveChangesAsync();

            return model.Id;
        }

        public virtual async Task<long> UpdateAsync(T model)
        {
            _context.Set<T>().Update(model);
            await _context.SaveChangesAsync();

            return model.Id;
        }
    }
}
