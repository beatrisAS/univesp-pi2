using System.Collections.Generic;

namespace univesp_pi2.Models
{
    public class ProfileViewModel
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string BirthDate { get; set; } = string.Empty;
        public bool IsAdmin { get; set; } = false;
    }
}