namespace TicketsAPI.Domain.Entities
{
    public class TicketStageEntity : BaseModel 
    {
        public string Description { get; set; }
        public string Status { get; set; }

    }
}
