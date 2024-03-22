namespace Ecommerce.DAL;

public class Product
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string ProductCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int MinimumQuantity { get; set; }
    public int DiscountRate { get; set; }

    public Category Category { get; set; } = null!;
    public ICollection<User> Users { get; set; } = new HashSet<User>();
}
