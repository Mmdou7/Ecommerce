using Ecommerce.DAL.Repositories.Products;
using static System.Reflection.Metadata.BlobBuilder;

namespace Ecommerce.DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IGenericRepository<User> UserRepository { get; private set; }
    public IGenericRepository<Product> ProductRepository { get; private set; }
    public IGenericRepository<UserProduct> UserProductRepository { get; private set; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        UserRepository = new UserRepository(_context);
        ProductRepository = new ProductRepository(_context);
        UserProductRepository = new UserProductRepository(_context);
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
