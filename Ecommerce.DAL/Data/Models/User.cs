namespace Ecommerce.DAL;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime LastLoginTime { get; set; }

    public ICollection<UserProduct> UserProducts { get; set; } = new HashSet<UserProduct>();
}
