namespace Aplicatie.API.Models
{
    public class LoginRequest
    {
        public required string Email { get; set; }
        public required string Parola { get; set; }
    }
}
