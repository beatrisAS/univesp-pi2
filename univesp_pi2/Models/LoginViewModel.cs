namespace univesp_pi2.Models
{
    public class LoginViewModel
    {
        public string User { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool RememberMe { get; set; }
    }
}