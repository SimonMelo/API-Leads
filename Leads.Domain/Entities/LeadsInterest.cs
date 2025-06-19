using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leads.Domain.Entities
{
    public class LeadsInterest
    {
        public int Id { get; set; }

        public int LeadId { get; set; }
        public Lead Lead { get; set; } = null!;

        public int PropertyId { get; set; }
        public string Status { get; set; }
        public decimal OfferPrice { get; set; }
        public Property Property { get; set; } = null!;

        public DateTime Timestamp { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
