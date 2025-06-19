using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leads.Domain.Entities
{
    public class InteractionBot
    {
        public int Id { get; set; }
        public int LeadId { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Direction { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public bool Sended { get; set; }

        public Lead Lead { get; set; } = null!;
    }
}
