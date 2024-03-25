namespace Ecommerce.DAL;

public class UserProductRepository : GenericRepository<UserProduct>, IUserProductRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    public UserProductRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

}
