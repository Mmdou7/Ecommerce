using Ecommerce.BL;
using Ecommerce.BL.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.APIs.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersManager _usersManager;
        public UsersController(IUsersManager usersManager)
        {
            _usersManager = usersManager;  
        }

        [HttpGet]
        public ActionResult<List<UserReadDTO>> GetAll()
        {
            return _usersManager.GetUsers().ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<UserReadDTO> GetById(int id)
        {
            return _usersManager.GetById(id);
        }

        [HttpPost]
        [Route("AddUser")]
        public ActionResult Add(UserAddDTO user)
        {
            var newId = _usersManager.Add(user);
            return CreatedAtAction(nameof(GetById),
                new { Id = newId },
                new GeneralResponse("Added"));
        }

        [HttpPut]
        [Route("UpdateUser")]
        public ActionResult Update(UserUpdateDTO user)
        {
            var isFound = _usersManager.Update(user);
            if (!isFound)
                NotFound();
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var isFound = _usersManager.Delete(id);

            if (!isFound)
                NotFound();

            return NoContent();
        }
    }
}
