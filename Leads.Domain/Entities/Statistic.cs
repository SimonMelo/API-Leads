using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leads.Domain.Entities
{
    public class Statistic
    {
        public int Id { get; set; }
        public string? Neighborhood { get; set; }
        public string? City { get; set; }
        public string? TypeProperty { get; set; }
        public string? InterestLead { get; set; }
        public int CountPeople { get; set; }
        public DateTime? LastSearch { get; set; }
    }

}
