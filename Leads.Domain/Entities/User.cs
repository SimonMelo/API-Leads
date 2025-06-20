using Leads.Domain.Enums;

namespace Leads.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string NameUser { get; set; }
        public string Email { get; set; }
        public string Cpf {  get; set; }
        public RoleEnum Role { get; set; }
        public string PasswordUser { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Actived { get; set; }
        public ICollection<Property> Properties { get; set; } = new List<Property>();
    }
}
