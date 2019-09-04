using System.Collections.Generic;
using GoodreadsCloneAPI.Models;
using GoodreadsCloneAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GoodreadsCloneAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IBaseService<User> _userService;

        public UsersController(IBaseService<User> userService)
        {
            _userService = userService;
        }

        // GET api/users
        [HttpGet]
        public List<User> Get()
        {
            return _userService.Get();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _userService.GetById(id);
        }

        // POST api/users
        [HttpPost]
        public void Post([FromBody] User user)
        {
            if(ModelState.IsValid)
            {
                _userService.Create(user);
            }
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user)
        {

            if(ModelState.IsValid)
            {
                user.Id = id;
                _userService.Update(user);
            }
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userService.Delete(id);
        }

    }
}