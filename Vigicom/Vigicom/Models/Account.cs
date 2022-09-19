using SQLite;

using System;
using System.Collections.Generic;
using System.Text;

namespace Vigicom.Models
{
    public class Account
    {
        [PrimaryKey]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string SimNumber { get; set; }
        
        public string UserPassword { get; set; }
    }
}
