using Administrativo.Pessoas.Eventos;
using CQRS;
using Infra.RabbitMQ.Produtor;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CasosDeUso.Administrativo.Handlers.Eventos
{
    public class PessoaFisicaCriadaHandler : IEventHandler<PessoaFisicaCriada>
    {
        public async Task Handle(PessoaFisicaCriada evento, CancellationToken cancellationToken)
        {
            using(var producer = new RabbitMQProducer<PessoaFisicaCriada>("pessoa-fisica"))
            {
                await producer.Publicar(evento);
            }
        }
    }
}
