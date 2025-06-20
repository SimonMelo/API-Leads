using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leads.Application.DTO.Requests
{
    public class RegisterUserRequest
    {
        public string NameUser { get; set; } = string.Empty;
        public string PasswordUser { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool Actived { get; set; } = true;
    }
}
