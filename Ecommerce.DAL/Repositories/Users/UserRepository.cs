﻿
namespace Ecommerce.DAL;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public bool ExistsByUsername(string username)
    {
        return _applicationDbContext.Users.Any(u => u.Username == username);
    }

    //public IEnumerable<User> GetAll()
    //{
    //    return _applicationDbContext.Set<User>();
    //}

    //public User? GetUserById(int id)
    //{
    //    return _applicationDbContext.Set<User>().Where(x => x.Id == id).FirstOrDefault();
    //}
    //public void AddUser(User user)
    //{
    //    _applicationDbContext.Set<User>().Add(user);
    //}
    //public void UpdateUser(User user)
    //{
    //    //_applicationDbContext.Set<User>().Update(user);
    //}

    //public void DeleteUser(User user)
    //{
    //    _applicationDbContext.Set<User>().Remove(user);
    //}

    //public int SaveChanges()
    //{
    //    return _applicationDbContext.SaveChanges();
    //}

}
