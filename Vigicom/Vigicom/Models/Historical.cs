using System;
using System.Collections.Generic;
using System.Text;

namespace Vigicom.Models
{
    public class Historical
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }
    }
}
