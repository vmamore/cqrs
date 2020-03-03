using Administrativo.Pessoas.Interfaces;
using Atendimento.Matriculas.Interfaces;
using Infra.Dados.MongoDb.Repositorios;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Dados.MongoDb
{
    public static class RegistroDependenciasMongo
    {
        public static IServiceCollection RegistrarDependenciasDoMongo(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPessoaFisicaEscritaRepositorio, PessoaFisicaEscritaRepositorio>();
            services.AddScoped<IMatriculaEscritaRepositorio, MatriculaEscritaRepositorio>();
            services.Configure<ConfigurationSettings>(options =>
            {
                options.ConnectionString = configuration.GetSection("MongoDbSettings")["ConnectionString"];
                options.Database = configuration.GetSection("MongoDbSettings")["DatabaseName"];
            });
            services.AddScoped<MongoDbContext>();

            return services;
        }
    }
}
