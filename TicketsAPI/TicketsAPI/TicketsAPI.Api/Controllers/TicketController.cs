using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TicketsAPI.Domain.DTOs;
using TicketsAPI.Domain.Interfaces.Services;

namespace TicketsAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateTicket(TicketPostRequestDto ticketPostDto)
        {
            try
            {
                var return200 = await _ticketService.CreateTicket(ticketPostDto);

                return Ok(return200);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message + (ex.InnerException != null ? "\n" + ex.InnerException?.Message : ""));
            }
        }

    }

}
