namespace Ecommerce.BL.DTOs;

public class UserAddDTO
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime LastLoginTime { get; set; }
}
