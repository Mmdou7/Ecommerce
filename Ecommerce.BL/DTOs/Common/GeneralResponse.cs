
namespace Ecommerce.BL.DTOs;

public class GeneralResponse
{
    public string Message { get; set; } = null!;
    public GeneralResponse(string msg)
    {
        Message = msg;
    }
}
