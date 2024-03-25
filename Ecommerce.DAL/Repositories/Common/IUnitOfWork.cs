namespace Ecommerce.DAL;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<User> UserRepository { get; }
    IGenericRepository<Product> ProductRepository { get; }
    IGenericRepository<UserProduct> UserProductRepository { get; }

    int SaveChanges();
}
