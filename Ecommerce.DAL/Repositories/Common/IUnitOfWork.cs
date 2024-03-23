namespace Ecommerce.DAL;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<User> UserRepository { get; }
    int SaveChanges();
}
