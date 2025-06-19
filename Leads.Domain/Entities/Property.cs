using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leads.Domain.Entities
{
    public class Property
    {
        public int Id { get; set; }
        public string TitleProperty { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string? Neighborhood { get; set; }
        public string? City { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
        public string TypeAd { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int? LeadId { get; set; } 
        public Lead? Lead { get; set; }

        public ICollection<LeadsInterest> Interests { get; set; } = new List<LeadsInterest>();
    }

}
