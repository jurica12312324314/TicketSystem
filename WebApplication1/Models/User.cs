using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class User
    {
        public User()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string TelephoneNumber { get; set; } = null!;
        public string Roles { get; set; } = null!;

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
