using Application.CasosDeUso.Administrativo.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Input.Administrativo;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaFisicaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PessoaFisicaController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PessoaFisicaDto dto)
        {
            var resultado = await _mediator.Send(
                new CadastrarPessoaFisica(
                    dto.CPF,
                    dto.Nome,
                    dto.Email,
                    dto.DataDeNascimento,
                    dto.Logradouro,
                    dto.CEP,
                    dto.Numero));

            if (resultado.Falhou)
            {
                return UnprocessableEntity(resultado);
            }

            return Created("", resultado);
        }
    }
}
