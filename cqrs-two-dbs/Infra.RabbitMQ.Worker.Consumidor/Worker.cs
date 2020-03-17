using System;
using System.Threading;
using System.Threading.Tasks;
using Infra.RabbitMQ.Worker.Consumidor.PessoaFisica;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Infra.RabbitMQ.Worker.Consumidor
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ISincronizador<PessoaFisicaData> _sincronizador;

        public Worker(ILogger<Worker> logger,
            ISincronizador<PessoaFisicaData> sincronizador)
        {
            _sincronizador = sincronizador;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var pessoaFisicaConsumer = new RabbitMQConsumidor<PessoaFisicaData>("pessoa-fisica");

                pessoaFisicaConsumer.Subscribe(async data => await _sincronizador.Sincronizar(data));

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }
        }
    }
}
