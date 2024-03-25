namespace Ecommerce.DAL.Repositories.Products;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    public ProductRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

}
