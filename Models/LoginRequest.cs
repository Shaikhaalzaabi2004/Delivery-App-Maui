namespace DeliveryApi.Models
{
    public class LoginRequest
    {
        public string Email { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;
    }
}
