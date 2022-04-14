using System;

namespace TicketsAPI.Domain.Entities
{
    public class TicketEntity : BaseModel
    {
        public int TypeId { get; set; }
        public int DoubtId { get; set; }
        public int StageId { get; set; }
        public int InteractionId { get; set; }
        public int CustomerPersonId { get; set; }
        public DateTime? OpeningDate { get; set; }
        public DateTime? ClosingDate { get; set; }

    }
}
