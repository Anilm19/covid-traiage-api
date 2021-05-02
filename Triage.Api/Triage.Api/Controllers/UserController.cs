using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Entity;
using Services;
using Triage.Api.Controllers.Base;

namespace Triage.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : DataApiBaseController<User, IEntityService<User>>
    {
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger,
                IEntityService<User> service,
                IUserService userService) : base(service, logger)
        {
            _userService = userService;
        }
        [HttpGet("getbyemail/{email}")]
        public virtual IActionResult GetByEmail(string email)
        {
            return Ok(_userService.GetUserByEmail(email));
        }
        [HttpPost()]
        public override IActionResult Post([FromBody] User item)
        {
            return Ok(_userService.CreateUser(item));
        }
    }
}
