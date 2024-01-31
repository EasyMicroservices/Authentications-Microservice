using EasyMicroservices.AuthenticationsMicroservice.Database.Contexts;
using EasyMicroservices.AuthenticationsMicroservice.Module;
using EasyMicroservices.AuthenticationsMicroservice.WebApi.Controllers;
using EasyMicroservices.Cores.AspEntityFrameworkCoreApi;
using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.Cores.Relational.EntityFrameworkCore.Intrerfaces;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace EasyMicroservices.AuthenticationsMicroservice.WebApi
{
    public class Program
    {

        public static async Task Main(string[] args)
        {
            var app = CreateBuilder(args);
            var build = await app.BuildWithUseCors<AuthenticationsContext>(null, true);
            build.MapControllers();
            build.Run();
        }

        static WebApplicationBuilder CreateBuilder(string[] args)
        {
            var app = StartUpExtensions.Create<AuthenticationsContext>(args);
            app.Services.Builder<AuthenticationsContext>("Authentication")
                .UseDefaultSwaggerOptions();
            app.Services.AddTransient<IEntityFrameworkCoreDatabaseBuilder, DatabaseBuilder>();
            app.Services.AddTransient(serviceProvider => new AuthenticationsContext(serviceProvider.GetService<IEntityFrameworkCoreDatabaseBuilder>()));
            AuthenticationRouting.ConfigureServices(app.Services);

            return app;
        }
    }
}