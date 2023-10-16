using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaPacientes.Infrastructure.Persistence.Context;
using SistemaPacientes.Infrastructure.Persistence.Repository;
using SistemaPacientes.Core.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistence (this IServiceCollection services, IConfiguration configuration)
        {
            #region Context
            if (configuration.GetValue<bool>("InMemoryDatabase"))
            {
                services.AddDbContext<SistemaPacienteContext>(options =>
                                   options.UseInMemoryDatabase("SistemaPaciente"));
            }
            else
            {
                services.AddDbContext<SistemaPacienteContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("SistemaPaciente")
               , m => m.MigrationsAssembly(typeof(SistemaPacienteContext).Assembly.FullName)));
            }
            #endregion

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IMedicoRepository, MedicoRepository>();
            services.AddTransient<IPacienteRepository, PacienteRepository>();
            services.AddTransient<IPruebaRepository, PruebaRepository>();
            services.AddTransient<IResultadoRepository, ResultadoRepository>();
            services.AddTransient<ICitaRepository, CitaRepository>();


            #endregion

        }
    }
}
