using SantanderTest.Services;

namespace SantanderTest.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection RegisterService(this IServiceCollection services)
        {
            services.AddScoped<IBestStoriesService, BestStoriesService>();

            return services;
        }

    }
}