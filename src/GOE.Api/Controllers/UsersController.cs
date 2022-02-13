using GOE.API.Filters;
using GOE.Application.Users.Commands.ConfirmUser;
using GOE.Application.Users.Commands.CreateUser;
using GOE.Application.Users.Commands.SendConfirmation;
using GOE.Application.Users.Queries.GetUsers;
using GOE.Application.Users.Queries.LoginUser;
using Microsoft.AspNetCore.Mvc;

namespace GOE.API.Controllers
{

    [ApiController]
    [Route("users")]
    public class UsersController : ApiControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            Console.WriteLine(Request.Host);
            var user = await Mediator.Send(command);
            if (user == null)
            {
                return BadRequest();
            }
            var url = "https://" + Request.Host + "/users/confirm/";
            var sendEmailReponse = await Mediator.Send(new SendConfirmationCommand
            {
                AppUrl = url,
                User = user,
            });
            return sendEmailReponse == false ? BadRequest() : Ok(user.Id);
        }

        [HttpGet]
        [AuthenticationFilter("Admin")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await Mediator.Send(new GetUsersQuery()));
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogInUser(LogInUserQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("confirm/{token}")]
        public async Task<IActionResult> ConfirmUser([FromRoute] string token)
        {
            var result = await Mediator.Send(new ConfirmUserCommand()
            {
                Token = token
            });
            return result == false ? BadRequest() : Ok("Email confirmed");
        }
    }
}
