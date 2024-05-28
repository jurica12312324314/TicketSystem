using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Category
    {
        public Category()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
