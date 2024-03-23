using System.ComponentModel.DataAnnotations;

namespace Ecommerce.BL;

public class LoginDTO
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
}

