using EasyMicroservices.AuthenticationsMicroservice.Database.Contexts;
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
            app.Services.Builder<AuthenticationsContext>("Authentication").UseDefaultSwaggerOptions();
            app.Services.AddTransient((serviceProvider) => new UnitOfWork(serviceProvider));
            app.Services.AddTransient(serviceProvider => new AuthenticationsContext(serviceProvider.GetService<IEntityFrameworkCoreDatabaseBuilder>()));
            app.Services.AddTransient<IEntityFrameworkCoreDatabaseBuilder, DatabaseBuilder>();
            app.Services.AddTransient<IBaseUnitOfWork, UnitOfWork>();
            app.Services.AddMvc()
                .AddApplicationPart(typeof(RoleController).Assembly);
            return app;
        }

        public static async Task Run(string[] args, Action<IServiceCollection> use)
        {
            var app = CreateBuilder(args);
            use?.Invoke(app.Services);
            var build = await app.Build<AuthenticationsContext>(true);
            build.MapControllers();

            build.Run();
        }
    }
}