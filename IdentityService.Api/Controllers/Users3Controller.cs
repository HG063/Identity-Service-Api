using IdentityService.Application.Interfaces.Services;
using IdentityService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdentityService.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Users3Controller : ControllerBase
    {

        private readonly ILogger<Users3Controller> _logger;
        private readonly IUserService _userService;
        public Users3Controller(IUserService userService, ILogger<Users3Controller> logger)
        {
            _logger = logger;
            _userService = userService;
            _logger.LogDebug(1, "NLog injected into Users3Controller");
        }
        // GET: api/<Users3Controller>

        [HttpGet]
        public async Task<ActionResult<List<UserDetails>>> Get()
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            try
            {
                _logger.LogInformation("Http Get User Request");
                var users = await _userService.GetUser();
                return Ok(users);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }
        }

        [HttpGet("{AplId}")]
        public async Task<ActionResult<List<UserDetails>>> Get(string AplId)
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            try
            { 
                _logger.LogInformation("Http Get User By AplId Request");
                var users = await _userService.GetUserByAplId(AplId);
                if (users.Any(x => x.AplId == AplId))
                    return Ok(users);
                else
                    return NotFound("AplId Not Found");
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }
        }

        // POST api/<Users3Controller>
        [HttpPost]
        public async Task<ActionResult<UserDetails>> Post(UserDetails users)
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            try
            {
                _logger.LogInformation("Http Post User Request");
                var Users = await _userService.CreateUser(users);
                if (string.IsNullOrEmpty(Users.UserName) || string.IsNullOrEmpty(Users.AplId) || string.IsNullOrEmpty(Users.RoleName) || Users.UserName == "string" || Users.RoleName == "string" || Users.RoleId == 0 ||
                    Users.AplId == "string")
                    return BadRequest("Check Post Fields, Fill Correct Entry In Post Fields");
                else
                    return Ok(Users);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }
        }

        // PUT api/<Users3Controller>/5
        [HttpPut]
        public async Task<ActionResult<UserDetails>> Put(UserDetails users)
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            try
            {
                _logger.LogInformation("Http Put User Request");
                var Users = await _userService.EditUser(users);
                if (string.IsNullOrEmpty(Users.UserName) || string.IsNullOrEmpty(Users.AplId) || string.IsNullOrEmpty(Users.RoleName) || Users.UserName == "string" || Users.RoleName == "string" || Users.RoleId == 0 ||
                    Users.AplId == "string")
                    return BadRequest("Check Put Fields, Fill Correct Entry In Put Fields");
                else
                    return Ok(Users);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }
        }

        // DELETE api/<Users3Controller>/5
        [HttpDelete("{AplId}")]
        public async Task<ActionResult<UserDetails>> Delete(string AplId)
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            try
            {
                _logger.LogInformation("Http Delete User Request");
                var users = await _userService.DeleteUser(AplId);
                //var users1 = await _userservice.getuserbyaplid(aplid);
                //if (users1.any(x => x.aplid == aplid))
                //    return Ok(users);
                //else
                //    return BadRequest("aplid not correct");
                return Ok(users);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;   
            }
        }
    }
}
