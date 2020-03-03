using Administrativo.Pessoas.Interfaces;
using Atendimento.Matriculas.Interfaces;
using Infra.Dados.SqlStorage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Dados.SqlStorage
{
    public static class RegistroDeDepenciasSQL
    {
        public static IServiceCollection RegistrarDependenciasSQL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPessoaFisicaFactory, PessoaFisicaFactory>();
            services.AddScoped<IMatriculaFactory, MatriculaFactory>();
            services.Configure<SqlServerSettings>(options =>
            {
                options.ConnectionString = configuration.GetSection("SqlServerSettings")["ConnectionString"];
            });
            services.AddScoped<ISqlServerConfigurations, SqlServerConfigurations>();

            return services;
        }
    }
}
