using Application.CasosDeUso.Administrativo.Commands;
using Core.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Input.Administrativo;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaFisicaController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public PessoaFisicaController(
            ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PessoaFisicaDto dto)
        {
            var resultado = await _commandDispatcher.ExecuteAsync(
                new CadastrarPessoaFisica(
                    dto.CPF,
                    dto.Nome,
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
