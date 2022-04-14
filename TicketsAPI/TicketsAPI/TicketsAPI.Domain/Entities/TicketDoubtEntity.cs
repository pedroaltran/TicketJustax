namespace TicketsAPI.Domain.Entities
{
    public class TicketDoubtEntity : BaseModel 
    {
        public int TypeId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

    }
}
