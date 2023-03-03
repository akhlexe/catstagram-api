using CatsTagram;
using CatsTagram.Infrastructure.Extensions;
using CatsTagram.Infrastructure.Filters;

var builder = WebApplication.CreateBuilder(args);

AppSettings appSettings = builder.Services.GetApplicationSettings(builder.Configuration);

builder.Services
    .AddDatabase(builder.Configuration)
    .AddIdentity()
    .AddJwtAuthentication(appSettings)
    .AddApplicationServices()
    .AddSwagger()
    .AddApiControllers();

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app
    .UseSwaggerUI()
    .UseRouting()
    .UseCors(options => options
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod())
    .UseAuthentication()
    .UseAuthorization()
    .UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    })
    .ApplyMigrations();

app.Run();
