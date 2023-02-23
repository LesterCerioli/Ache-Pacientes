using AchePacientes.Application.Handlers.TokenUseCase;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace AchePacientes.Api.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class TokenController : ControllerBase
    {
        private readonly ILogger<TokenController> _logger;
        private readonly IMediator _mediator;

        public TokenController(ILogger<TokenController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("send-token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendToken([FromBody] SendTokenRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Errors.Any())
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("validate-token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ValidateToken([FromBody] ValidateTokenRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Errors.Any()) 
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
