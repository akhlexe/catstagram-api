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
    }
}
