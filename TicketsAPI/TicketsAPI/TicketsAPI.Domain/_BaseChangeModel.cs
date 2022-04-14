using System;

namespace TicketsAPI.Domain
{
    public class BaseChangeModel : BaseModel
    {
        public long ChangeUserId { get; set; }
        public UserView ChangeUser { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
