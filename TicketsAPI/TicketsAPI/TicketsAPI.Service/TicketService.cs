using System.Threading.Tasks;
using TicketsAPI.Domain.DTOs;
using TicketsAPI.Domain.Interfaces.Repos.Writable;
using TicketsAPI.Domain.Interfaces.Services;

namespace TicketsAPI.Service
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public async Task<bool> CreateTicket(TicketPostRequestDto ticketPostDto)
        {
            await _ticketRepository.InsertAsync(ticketPostDto);
        }
    }
}
