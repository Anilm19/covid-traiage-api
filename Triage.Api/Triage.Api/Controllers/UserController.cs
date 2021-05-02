using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.DTO;
using Models.Entity;
using Models.Enum;
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
        [HttpGet("getusersbypermission/{persmission}")]
        public virtual IActionResult GetUsersByPermission(UserPermission persmission)
        {
            return Ok(_userService.GetUsersByPermission(persmission));
        }
        [HttpGet("promotetohealthworker/{email}")]
        public virtual IActionResult PromoteToHealthWorker(string email)
        {
            return Ok(_userService.GetUserByEmail(email));
        }
        [HttpPost()]
        public override IActionResult Post([FromBody] User item)
        {
            return Ok(_userService.CreateUser(item));
        }
        [HttpPost("assignpatients")]
        public IActionResult AssignPatients([FromBody] AssignPatientRequest request)
        {
            _userService.AssignPatients(request);
            return Ok();
        }
        [HttpGet("assignpatients/{email}")]
        public IActionResult GetAssignedPatients(string email)
        {
            _userService.GetAssignedPatients(email);
            return Ok();
        }

    }
}
