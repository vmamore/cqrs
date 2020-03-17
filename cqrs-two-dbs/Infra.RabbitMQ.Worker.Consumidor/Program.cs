using Infra.Dados.SqlStorage;
using Infra.RabbitMQ.Worker.Consumidor.PessoaFisica;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infra.RabbitMQ.Worker.Consumidor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.Configure<SqlServerSettings>(options =>
                    {
                        options.ConnectionString = hostContext.Configuration.GetSection("SqlServerSettings")["ConnectionString"];
                    });
                    services.AddSingleton<ISincronizador<PessoaFisicaData>, PessoaFisicaSincronizador>();
                    services.AddSingleton<ISqlServerConfigurations, SqlServerConfigurations>();
                    services.AddHostedService<Worker>();
                });
    }
}
