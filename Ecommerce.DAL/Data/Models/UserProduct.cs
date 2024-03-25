namespace Ecommerce.DAL;

public class UserProduct
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public DateTime ModifiedOn { get; set; }

    public User User { get; set; }
    public Product Product { get; set; }
}
