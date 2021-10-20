using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Restful.Models;
using Restful.Models.DTO;
using Restful.Repositorys;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController
    {
        private readonly IUser _repository;

        //Dependency injection 
        public UserController(IUser repository)
        {
            _repository = repository;
        }


        // Create user endpoint, heller ikke det store her
        // Bruger CreateUser logic fra User.cs
        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<UserLogin> CreateUser([FromBody] CreateUserDTO user)
        {
            var userdata = await _repository.CreateUser(user.Username, user.Password, user.Fullname, user.Email);

            return userdata;
        }

        // Endpoint for JWT login, retunerner enten UnauthorizedObjectResult eller OkObjectResult
        // Afhænging om loginet er rigtig
        // Bruger JWT Logic fra User.cs

        [AllowAnonymous]
        [Route("authenticate")]
        [HttpPost]
        public ActionResult Login([FromBody] UserLoginDTO user)
        {
            var token = _repository.Authenticate(user.Username, user.Password);
            if (token == null)
                return new UnauthorizedObjectResult(token);

            return new OkObjectResult(token);
        }
    }
}
