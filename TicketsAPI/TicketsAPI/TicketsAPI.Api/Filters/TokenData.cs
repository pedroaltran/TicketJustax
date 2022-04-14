using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketsAPI.Api.Filters
{
    public static class TokenData
    {
        public static string UserEmail { get; set; }
        public static string UserFullName { get; set; }
        public static Int64 UserId { get; set; }

        public static void Clear()
        {
            UserEmail = null;
            UserFullName = null;
            UserId = 0;
        }
    }
}
