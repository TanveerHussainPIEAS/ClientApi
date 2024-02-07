using ClientApi.Services;

namespace ClientApi.Infrastructure.Configurations
{
    public static class DependancyInjectionConfiguration
    {
        public static void AddDIContainerService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IProductTpeService, ProductTpeService>();
            // Add new Service here
        }
    }
}
