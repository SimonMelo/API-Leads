namespace Leads.Domain.Entities
{
    public class Lead
    {
        public int Id { get; set; }
        public string NameLead { get; set; } = string.Empty;
        public string PhoneLead { get; set; } = string.Empty;
        public string InterestLead { get; set; } = string.Empty;
        public string? Neighborhood { get; set; }
        public string? City { get; set; }
        public string? TypeProperty { get; set; }
        public decimal? PriceMax { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Origin { get; set; }
        public ICollection<InteractionBot> Interactions { get; set; } = new List<InteractionBot>();
        public ICollection<LeadsInterest> Interests { get; set; } = new List<LeadsInterest>();
    }

}
