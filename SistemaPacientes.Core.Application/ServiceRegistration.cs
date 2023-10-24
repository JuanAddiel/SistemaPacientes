using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaPacientes.Core.Application.Interfaces.Repositories;
using SistemaPacientes.Core.Application.Interfaces.Services;
using SistemaPacientes.Core.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer (this IServiceCollection services, IConfiguration configuration)
        {
            #region Services
            services.AddTransient<ICitaServices, CitaServices>();
            services.AddTransient<IMedicoServices, MedicoServices>();
            services.AddTransient<IPacienteServices, PacienteServices>();
            services.AddTransient<IPruebaServices, PruebaLaboratorioServices>();
            services.AddTransient<IResultadoServices, ResultadoLaboratorioServices>();
            services.AddTransient<IUsuarioServices, UsuarioServices>();
            services.AddTransient<IRoleServices, RoleServices>();
            #endregion
        }
    }
}
