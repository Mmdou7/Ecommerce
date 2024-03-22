using Azure.Core;
using Ecommerce.BL.DTOs;
using Ecommerce.DAL;

namespace Ecommerce.BL;

public class UsersManager : IUsersManager
{
    private readonly IUserRepository _userRepository;
    public UsersManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        
    }

    public UserReadDTO GetById(int id)
    {
        var user = _userRepository.GetUserById(id);
        if (user == null)
            return null;
        
        return new UserReadDTO
        {
            Id = id,
            Username = user.Username,
            Email = user.Email,
            LastLoginTime = user.LastLoginTime,
        };
    }

    public IEnumerable<UserReadDTO> GetUsers()
    {
        var users = _userRepository.GetAll();
        return users.Select(x => new UserReadDTO
        {
            Id = x.Id,
            Username = x.Username,
            Email = x.Email,
            LastLoginTime = x.LastLoginTime,
        });
    }
    public int Add(UserAddDTO userAdd)
    {
        User user = new User
        {
            Username = userAdd.Username,
            Email = userAdd.Email,
            Password = userAdd.Password,
            LastLoginTime = userAdd.LastLoginTime,
        };
        _userRepository.AddUser(user);
        _userRepository.SaveChanges();
        return user.Id;
    }
    public bool Update(UserUpdateDTO userUpdate)
    {
        User? user = _userRepository.GetUserById(userUpdate.Id);
        if (user == null) return false;
        user.Username = userUpdate.Username;
        user.Email = userUpdate.Email;
        user.Password = userUpdate.Password;

        _userRepository.UpdateUser(user);
        _userRepository.SaveChanges();

        return true;
    }

    public bool Delete(int id)
    {
        User? user = _userRepository.GetUserById(id);
        if (user == null) return false;

        _userRepository.DeleteUser(user);
        _userRepository.SaveChanges();

        return true;
    }
    
}
