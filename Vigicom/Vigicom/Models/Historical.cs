using System;

namespace Vigicom.Models
{
    public class Historical
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public Guid AccountId { get; set; }
    }
}
