using System.Threading.Tasks;
using TicketsAPI.Domain.Entities;
using TicketsAPI.Domain.Interfaces.Repos.Writable;

namespace TicketsAPI.Data.Writable
{
    public class TicketRepository : ITicketRepository
    {
        public Task DeleteAsync(TicketEntity model)
        {
            throw new System.NotImplementedException();
        }

        public Task<long> InsertAsync(TicketEntity model)
        {
            throw new System.NotImplementedException();
        }

        public Task<long> UpdateAsync(TicketEntity model)
        {
            throw new System.NotImplementedException();
        }
    }
}
