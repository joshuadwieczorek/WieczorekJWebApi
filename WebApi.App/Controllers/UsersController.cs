using Global.Library.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Contracts;
using WebApi.Library.Services;

namespace WebApi.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : WebApiControllerBase<UsersController>
    {
        private readonly IUsersService _usersService;


        public UsersController(
              ILogger<UsersController> logger
            , Bugsnag.IClient bugSnag
            , IUsersService usersService) : base(logger, bugSnag)
        {
            _usersService = usersService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                // Do any permission checking here...


                var users = await _usersService.Read();
                if (users != null && users.Any())
                    return Ok(users);

                return NoContent();
            }
            catch (Exception e)
            {
                LogError(e);
                return StatusCode(500, "Internal server error!");
            }
        }


        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(Guid userId)
        {
            try
            {
                // Do any permission checking here...


                var user = await _usersService.Read(userId);
                if (user != null)
                    return Ok(user);

                return NoContent();
            }
            catch (Exception e)
            {
                LogError(e);
                return StatusCode(500, "Internal server error!");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            try
            {
                // Do any permission checking here...


                var newUser = await _usersService.Create(user);
                if (newUser == null)
                    throw new ArgumentException(nameof(newUser));

                return StatusCode(201, user);
            }
            catch (Exception e)
            {
                LogError(e);
                return StatusCode(500, "Internal server error!");
            }
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] User user)
        {
            try
            {
                // Do any permission checking here...


                var updatedUser = await _usersService.Update(user);
                if (updatedUser == null)
                    throw new ArgumentException(nameof(updatedUser));

                return Ok(user);
            }
            catch (Exception e)
            {
                LogError(e);
                return StatusCode(500, "Internal server error!");
            }
        }


        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(Guid userId)
        {
            try
            {
                // Do any permission checking here...

                await _usersService.Delete(userId);
                return NoContent();
            }
            catch (Exception e)
            {
                LogError(e);
                return StatusCode(500, "Internal server error!");
            }
        }
    }
}