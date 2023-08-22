namespace ClientApi.Infrastructure.Configurations
{
    public static class Cors
    {
        public static void AddCorsService(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsApp",
                      builder =>
                      {
                          builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
                      });
            });
        }
    }
}
