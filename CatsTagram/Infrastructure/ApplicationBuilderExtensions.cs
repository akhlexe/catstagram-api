using CatsTagram.Data;
using Microsoft.EntityFrameworkCore;

namespace CatsTagram.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            CatstagramDbContext? dbContext = services.ServiceProvider.GetService<CatstagramDbContext>();

            dbContext?.Database.Migrate();
        }

        public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app)
            => app
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("swagger/v1/swagger.json", "My API V1");
                    options.RoutePrefix = string.Empty;
                });
    }
}
