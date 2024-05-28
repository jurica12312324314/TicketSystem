using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            EscalationProcesses = new HashSet<EscalationProcess>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public string State { get; set; } = null!;
        public string Priority { get; set; } = null!;

        public virtual Category Category { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<EscalationProcess> EscalationProcesses { get; set; }
    }
}
