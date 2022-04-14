namespace TicketsAPI.Domain.Entities
{
    public class TicketTypeEntity : BaseModel 
    {
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
