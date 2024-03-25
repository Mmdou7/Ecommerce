namespace Ecommerce.DAL;

public interface IUserRepository : IGenericRepository<User>
{
    bool ExistsByUsername(string username);
}
