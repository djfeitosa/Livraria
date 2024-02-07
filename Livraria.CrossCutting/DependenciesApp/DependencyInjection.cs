using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Domain.Abstractions;
using Livraria.Infraestructure.Context;
using Livraria.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Livraria.CrossCutting.DependenciesApp
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraEstructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionDesMac");

            services.AddDbContext<ApplicationDbContext>(opt => opt.UseMySql(connectionString,
                                    ServerVersion.AutoDetect(connectionString)));

            services.AddScoped<ILivroRepository, LivroRepository>();

            return services;
        }

    }
}