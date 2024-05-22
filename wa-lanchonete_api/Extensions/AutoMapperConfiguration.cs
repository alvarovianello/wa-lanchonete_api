using Application.ProfileMapper;

namespace wa_lanchonete_api.Extensions
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddResolveAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Application.ProfileMapper.AutoMapper).Assembly);
            return services;
        }
    }
}
