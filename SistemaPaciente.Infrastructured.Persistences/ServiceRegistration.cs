using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaPaciente.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPaciente.Infrastructure.Persistence
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
            #endregion

        }
    }
}
