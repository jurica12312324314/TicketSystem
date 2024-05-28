using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class UserTicketUpdate
    {
        public int UserId { get; set; }
        public int TicketId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string ChangedColumn { get; set; } = null!;
        public string Reason { get; set; } = null!;

        public virtual Ticket Ticket { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
