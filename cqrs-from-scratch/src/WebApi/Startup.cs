using Application.CasosDeUso.Administrativo.Commands;
using Application.CasosDeUso.Administrativo.Handlers;
using Application.CasosDeUso.Atendimento.Commands;
using Application.CasosDeUso.Atendimento.Handlers.Eventos;
using Application.CasosDeUso.Atendimento.Handlers.Queries;
using Atendimento.Matriculas.Eventos;
using CQRS;
using CQRS.Commands;
using CQRS.Events;
using CQRS.Queries;
using Dados;
using Dados.Extensoes;
using Dados.Queries.Atendimento.ModeloDeLeitura;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("CQRSFromScratchConnectionString");

            services.AddDbContext<Context>(options => {
                options.UseSqlServer(connectionString);
            }, ServiceLifetime.Singleton);

            services.AddSwaggerGen(c =>
           {
               c.SwaggerDoc("v1", new OpenApiInfo { Title = "CQRS API", Version = "V1" });
           });
            
            services.RegistrarDependenciasDeDados();
            services.RegistrarDependenciasDoCQRS();
            services.AddTransient<ICommandHandler<CadastrarPessoaFisica>, CadastrarPessoaFisicaHandler>();
            services.AddTransient<ICommandHandler<RealizarMatricula>, RealizarMatriculaHandler>();
            services.AddTransient<IQueryHandler<TurmasEAlunosQuery, IEnumerable<AlunosPorTurmaListItem>>, TurmasEAlunosQueryHandler>();
            services.AddTransient<IEventHandler<MatriculaRealizadaComSucesso>, MatriculaRealizadaComSucessoHandler>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.EnsureMigrations<Context>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CQRS API");
            });
        }
    }
}
