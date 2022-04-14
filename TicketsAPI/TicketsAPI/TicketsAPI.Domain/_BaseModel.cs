using System;
using TicketsAPI.Domain.Interfaces;

namespace TicketsAPI.Domain
{
    public class BaseModel : IBaseModel
    {
        public long Id { get; set; }
        public long CreatedUserId { get; set; }
        public long UpdatedUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
