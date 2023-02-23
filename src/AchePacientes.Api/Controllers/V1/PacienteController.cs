using AchePacientes.Application.Handlers.Paciente;
using AchePacientes.Application.Services.Pacientes.Contratos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AchePacientes.Api.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly ILogger<PacienteController> _logger;
        private readonly IMediator _mediator;

        public PacienteController(ILogger<PacienteController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreatePacienteCommand createCommand)
        {
            var result = await _mediator.Send(createCommand);
            if (result.Errors.Any())
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet]
        [Route("exists/cpf/{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CpfExists([FromRoute] string cpf)
        {            
            var result = await _mediator.Send(new CheckPacienteExistsByCpfRequest(cpf));
            if (result.Errors.Any())
            {
                return BadRequest(result);
            }
            if (result.Exists)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [HttpGet]
        [Route("exists/date-of-birth/{dateofbirth}/cpf/{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CpfDateExists([FromRoute] string cpf, [FromRoute] DateTime dateofbirth)
        {
            var result = await _mediator.Send(new CheckPacienteExistsByCpfAndDtOfBirthRequest(cpf, dateofbirth));
            if (result.Errors.Any())
            {
                return BadRequest(result);
            }
            if (result.Exists)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }


    }
}
