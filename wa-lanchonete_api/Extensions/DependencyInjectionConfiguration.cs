using Application.Services;
using Application.Services.Interfaces;
using Domain.Base;
using Domain.Repositories;
using Infra.Data;
using Infra.Data.Base;
using Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace wa_lanchonete_api.Extensions
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddResolveDependencies(this WebApplicationBuilder builder)
        {
            IServiceCollection services = builder.Services;
            var configuration = builder.Configuration;
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddTransient<ICustomerService, CustomerService>();            
            services.AddTransient<ICustomerRepository, CustomerRepository>();

            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services.AddTransient<IDbConnectionFactory, DbConnectionFactory>((ctx) =>
            {
                return new DbConnectionFactory(connectionString);
            });
            services.AddDbContext<LanchoneteDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddHttpClient();

            return services;
        }
    }
}
