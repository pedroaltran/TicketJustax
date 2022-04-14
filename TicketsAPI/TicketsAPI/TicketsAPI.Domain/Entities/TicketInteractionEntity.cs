using System;

namespace TicketsAPI.Domain.Entities
{
    public class TicketInteractionEntity : BaseModel
    {
        public string Message { get; set; }
        public DateTime? InteractionDate { get; set; } 
    }
}
