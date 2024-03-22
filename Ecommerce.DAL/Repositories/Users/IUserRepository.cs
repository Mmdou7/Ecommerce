

namespace Ecommerce.DAL;

public interface IUserRepository
{
    IEnumerable<User> GetAll();
    User? GetUserById(int id);
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(User user);
    int SaveChanges();
}
