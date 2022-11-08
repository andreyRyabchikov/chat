using System.Globalization;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using chat.Entity.Models;
using chat.Repository;
using Microsoft.AspNetCore.Mvc;

namespace chat.WebAPI.Controllers
{
    /// <summary>
    /// Doctors endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IRepository<User> _repository;

        /// <summary>
        /// Users controller
        /// </summary>
        public UsersController(IRepository<User> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUsers()
        {
            var mytUser = new User()
            {
                PasswordHash = "234423412",
                Login = "dsfgdfg",
                Name = "Abgfdg",
                Ban = false,
                RegistrationDate= new DateTime(2008, 5, 1, 8, 30, 52),
                BirthDate= new DateTime(1999, 5, 1, 8, 30, 52)
            };
            _repository.Save(mytUser);
            mytUser.Login = "znn";
            _repository.Save(mytUser);
            var users = _repository.GetAll();
            return Ok(users);
        }
          /// <summary>
        /// Delete users
        /// </summary>
        /// <param name="user"></param>
        [HttpDelete]
        public IActionResult DeleteUsers(User user)
        {
            _repository.Delete(user);
            return Ok();
        }
        /// <summary>
        /// Post users
        /// </summary>
        /// <param name="user"></param>
        [HttpPost]
        public IActionResult PostUsers(User user)
        {
            var result = _repository.Save(user);
            return Ok(result);
        }

        /// <summary>
        /// Update users
        /// </summary>
        /// <param name="user"></param>
        [HttpPut]
        public IActionResult Updatesers(User user)
        {
            return PostUsers(user);
        }
    }
}