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
            throw new ValidationException($"User with ID {id} not found.");

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
    public int Add(UserAddDTO user)
    {
        User userEntity = new User
        {
            Username = user.Username,
            Email = user.Email,
            Password = user.Password,
            LastLoginTime = user.LastLoginTime,
        };
        _userRepository.AddUser(userEntity);
        _userRepository.SaveChanges();
        return userEntity.Id;
    }
    public bool Update(UserUpdateDTO user)
    {
        User? userEntity = _userRepository.GetUserById(user.Id);
        if (userEntity == null) return false;
        userEntity.Username = user.Username;
        userEntity.Email = user.Email;
        userEntity.Password = user.Password;

        _userRepository.UpdateUser(userEntity);
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
