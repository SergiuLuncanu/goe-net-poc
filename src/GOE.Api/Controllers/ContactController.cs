using GOE.Application.Contact.Commands;
using Microsoft.AspNetCore.Mvc;

namespace GOE.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> ContactUs(ContactCommand command)
        {
            var result = await Mediator.Send(command);
            return result == true ? Ok() : BadRequest();
        }
    }
}
