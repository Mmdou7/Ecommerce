using Ecommerce.BL.DTOs;

namespace Ecommerce.BL;

public interface IUsersManager
{
    IEnumerable<UserReadDTO> GetUsers();
    UserReadDTO GetById(int id);
    int Add(UserAddDTO user);
    bool Update(UserUpdateDTO user);
    bool Delete(int id);

}
