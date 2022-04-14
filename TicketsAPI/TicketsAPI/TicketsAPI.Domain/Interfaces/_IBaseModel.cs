using System;

namespace TicketsAPI.Domain.Interfaces
{
    public interface IBaseModel
    {
        long Id { get; set; }
        long CreatedUserId { get; set; }
        long UpdatedUserId { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }

    }
}
