using EasyMicroservices.AuthenticationsMicroservice.Database.Contexts;
using EasyMicroservices.AuthenticationsMicroservice.Interfaces;
using EasyMicroservices.Cores.AspEntityFrameworkCoreApi;
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
            var build = await app.Build<AuthenticationsContext>(true, true);

            //build.UseAuthentication();
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
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    BearerFormat = "JWT",
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter your token in the text input below.\r\n Example: \"Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
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
            });
            app.Services.AddTransient((serviceProvider) => new UnitOfWork(serviceProvider));
            app.Services.AddTransient(serviceProvider => new AuthenticationsContext(serviceProvider.GetService<IEntityFrameworkCoreDatabaseBuilder>()));
            app.Services.AddTransient<IEntityFrameworkCoreDatabaseBuilder, DatabaseBuilder>();
            StartUpExtensions.AddWhiteLabel("Authentication", "RootAddresses:WhiteLabel");

            app.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin();
                                  });
            });

            app.Services.AddScoped<IJWTManager, JWTManager>();

            app.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = app.Configuration["JWT:Issuer"],
                        ValidAudience = app.Configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(app.Configuration["Jwt:Key"]))
                    };
                });

            return app;
        }

        public static async Task Run(string[] args, Action<IServiceCollection> use)
        {
            var app = CreateBuilder(args);
            use?.Invoke(app.Services);
            var build = await app.Build<AuthenticationsContext>(true, true);
            build.MapControllers();

            build.Run();
        }
    }
}