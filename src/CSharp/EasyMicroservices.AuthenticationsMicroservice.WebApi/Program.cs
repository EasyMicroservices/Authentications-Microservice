using EasyMicroservices.AuthenticationsMicroservice.Database.Contexts;
using EasyMicroservices.Cores.AspEntityFrameworkCoreApi;
using EasyMicroservices.Cores.AspEntityFrameworkCoreApi.Interfaces;
using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.Cores.Relational.EntityFrameworkCore.Intrerfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace EasyMicroservices.AuthenticationsMicroservice.WebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var app = CreateBuilder(args);
            var build = await app.Build<AuthenticationsContext>(true);
            build.MapControllers();
            build.UseCors(MyAllowSpecificOrigins);
            build.Run();
        }

        static readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        static WebApplicationBuilder CreateBuilder(string[] args)
        {
            var app = StartUpExtensions.Create<AuthenticationsContext>(args);
            app.Services.Builder<AuthenticationsContext>(options =>
            {
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            //Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            }).UseDefaultSwaggerOptions();
            app.Services.AddTransient((serviceProvider) => new UnitOfWork(serviceProvider));
            app.Services.AddTransient(serviceProvider => new AuthenticationsContext(serviceProvider.GetService<IEntityFrameworkCoreDatabaseBuilder>()));
            app.Services.AddTransient<IEntityFrameworkCoreDatabaseBuilder, DatabaseBuilder>();
            app.Services.AddTransient<IBaseUnitOfWork, UnitOfWork>();
            StartUpExtensions.AddWhiteLabel("Authentication", "RootAddresses:WhiteLabel");
            StartUpExtensions.AddAuthentication("RootAddresses:Authentication");

            app.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin();
                                  });
            });
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