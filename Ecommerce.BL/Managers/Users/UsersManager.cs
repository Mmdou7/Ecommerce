using Azure.Core;
using Ecommerce.BL.DTOs;
using Ecommerce.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.BL;

public class UsersManager : IUsersManager
{
    private readonly IConfiguration _configuration;
    private readonly IUnitOfWork _unitOfWork;
    public UsersManager(IUnitOfWork unitOfWork, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _configuration = configuration;
    }

    public UserReadDTO GetById(int id)
    {
        var user = _unitOfWork.UserRepository.GetById(id);
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
        var users = _unitOfWork.UserRepository.GetAll();
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
        if (_unitOfWork.UserRepository.GetAll().Where(x=>x.Username == user.Username || x.Email == user.Email).Any())
        {
            throw new ValidationException("Username already exists.");
        }
        User userEntity = new User
        {
            Username = user.Username,
            Email = user.Email,
            Password = user.Password,
            LastLoginTime = user.LastLoginTime,
        };
        _unitOfWork.UserRepository.Add(userEntity);
        _unitOfWork.SaveChanges();
        return userEntity.Id;
    }
    public bool Update(UserUpdateDTO user)
    {
        User? userEntity = _unitOfWork.UserRepository.GetById(user.Id);
        if (userEntity == null) return false;
        userEntity.Username = user.Username;
        userEntity.Email = user.Email;
        userEntity.Password = user.Password;

        _unitOfWork.UserRepository.Update(userEntity);
        _unitOfWork.SaveChanges();

        return true;
    }

    public bool Delete(int id)
    {
        User? user = _unitOfWork.UserRepository.GetById(id);
        if (user == null) return false;

        _unitOfWork.UserRepository.Delete(user);
        _unitOfWork.SaveChanges();

        return true;
    }

    public string Login(LoginDTO model)
    {
        var existedUser = _unitOfWork.UserRepository.GetAll().FirstOrDefault(x => x.Username == model.UserName && x.Password == model.Password);
        if (existedUser is not null)
        {
            var userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, existedUser.Username),
                new Claim(ClaimTypes.Email , $"{existedUser.Username}@gmail.com"),
                new Claim("Nationality","Egyptian")
            };

            var secretKey = _configuration["SecretKey"];

            var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKey);

            var key = new SymmetricSecurityKey(secretKeyInBytes);

            var methodUsedInGeneratingToken = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var jwt = new JwtSecurityToken(
                claims: userClaims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: methodUsedInGeneratingToken
                );
            var tokenHandler = new JwtSecurityTokenHandler();

            string tokenString = tokenHandler.WriteToken(jwt);

            return tokenString;

        }
        throw new ValidationException($"Not Auth");
    }
}
