using System.Threading.Tasks;
using TicketsAPI.Domain.DTOs;

namespace TicketsAPI.Domain.Interfaces.Services
{
    public interface ITicketService
    {
        Task<bool> CreateTicket(TicketPostRequestDto ticketPostDto);
    }
}
