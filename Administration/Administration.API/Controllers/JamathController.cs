using Administration.Application.Jamaths.Commands;
using Administration.Application.Jamaths.DTOs;
using Administration.Application.Jamaths.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Administration.API.Controllers
{
    [Route("api/jamaths")]
    [ApiController]
    public class JamathController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JamathController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<JamathDto>>> GetAllAsync()
        {
            //var jamath = await _mediator.Send(new)
            return Ok();
        }

        [HttpGet("{id:int}")]
        //[HttpGet("GetJamathById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var jamath = await _mediator.Send(new GetJamathByIdQuery(id));
            if (jamath == null)
            {
                return NotFound();
            }
            return Ok(jamath);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(DateTime fromDate, DateTime toDate)
        {
            var jamathId = await _mediator.Send(new CreateJamathCommand(fromDate, toDate));
            return CreatedAtAction(nameof(GetByIdAsync), new {id = jamathId});
        }
    }
}
