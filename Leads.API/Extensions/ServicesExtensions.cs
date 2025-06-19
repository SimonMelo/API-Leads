using Leads.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Leads.API.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<LeadDbContext>(options =>
            options.UseMySql(config.GetConnectionString("DB_LEADS"), 
            ServerVersion.AutoDetect(config.GetConnectionString("DB_LEADS"))
            ));

            return services;
        }

        public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            
            return services;
        }

        public static IServiceCollection AddHealthCheckService(this IServiceCollection services)
        {
            services.AddHealthChecks();
            return services;
        }

        public static IServiceCollection AddAutoMapperService(this  IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
