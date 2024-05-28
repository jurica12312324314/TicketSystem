using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class EscalationProcess
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string TriggerReason { get; set; } = null!;

        public virtual Ticket Ticket { get; set; } = null!;
    }
}
