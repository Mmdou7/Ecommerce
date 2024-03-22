
namespace Ecommerce.DAL;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    public UserRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public IEnumerable<User> GetAll()
    {
        return _applicationDbContext.Set<User>();
    }

    public User? GetUserById(int id)
    {
        return _applicationDbContext.Set<User>().Where(x => x.Id == id).FirstOrDefault();
    }
    public void AddUser(User user)
    {
        _applicationDbContext.Set<User>().Add(user);
    }
    public void UpdateUser(User user)
    {
        //_applicationDbContext.Set<User>().Update(user);
    }

    public void DeleteUser(User user)
    {
        _applicationDbContext.Set<User>().Remove(user);
    }

    public int SaveChanges()
    {
        return _applicationDbContext.SaveChanges();
    }

}
