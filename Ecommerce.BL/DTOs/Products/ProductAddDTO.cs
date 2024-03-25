namespace Ecommerce.BL.DTOs;

public class ProductAddDTO
{
    public int CategoryId { get; set; }
    public string ProductCode { get; set; }
    public string Name { get; set; }
    public string ImagePath { get; set; }
    public decimal Price { get; set; }
    public int DiscountRate { get; set; }
    public int UserId { get; set; }
}

