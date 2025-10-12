using Administration.Application.Contributors.Commands.CreateContributor;
using Administration.Application.Contributors.DTOs;
using Administration.Application.Contributors.Queries;
using Administration.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Administration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());
            return Ok(users);
        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById(Guid Id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(Id));
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Create([FromForm] UserCreateRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _mediator.Send(new CreateUserCommand(request));
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }
    }
}
