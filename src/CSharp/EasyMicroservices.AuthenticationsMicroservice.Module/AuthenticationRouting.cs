using EasyMicroservices.AuthenticationsMicroservice.WebApi.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Linq;

namespace EasyMicroservices.AuthenticationsMicroservice.Module;
public static class AuthenticationRouting
{
    public static void ConfigureServices(IServiceCollection services, string prefix = "")
    {
        IMvcBuilder mvcBuilder;
        if (prefix.HasAny())
        {
            mvcBuilder = services.AddControllersWithViews(options =>
            {
                options.Conventions.Add(new RoutePrefixConvention(new RouteAttribute(prefix)));
            });
        }
        else
        {
            mvcBuilder = services.AddMvc();
        }
        mvcBuilder.AddApplicationPart(typeof(RoleController).Assembly);
    }

    public static void ConfigurSwagger(IServiceCollection services, string name = "Authentication")
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(name, new OpenApiInfo { Title = $"{name} Module", Version = "v1" });
        });
        services.AddMvc(c =>
        {
            c.Conventions.Add(new ApiExplorerGroupPerVersionConvention()
            {
                Prefix = name
            });
        });
    }

    public static void ConfigureAll(IServiceCollection services, string prefix = "Authentication")
    {
        ConfigureServices(services, prefix);
        ConfigurSwagger(services, prefix);
    }
}

public class RoutePrefixConvention : IApplicationModelConvention
{
    private readonly AttributeRouteModel _prefix;

    public RoutePrefixConvention(IRouteTemplateProvider routeTemplateProvider)
    {
        _prefix = new AttributeRouteModel(routeTemplateProvider);
    }

    public void Apply(ApplicationModel application)
    {
        foreach (var controller in application.Controllers)
        {
            var matchedSelectors = controller.Selectors.Where(x => x.AttributeRouteModel != null).ToList();
            if (matchedSelectors.Any())
            {
                foreach (var selectorModel in matchedSelectors)
                {
                    selectorModel.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(_prefix,
                        selectorModel.AttributeRouteModel);
                }
            }
            else
            {
                controller.Selectors.Add(new SelectorModel
                {
                    AttributeRouteModel = _prefix
                });
            }
        }
    }
}
public class ApiExplorerGroupPerVersionConvention : IControllerModelConvention
{
    public string Prefix { get; set; }
    public void Apply(ControllerModel controller)
    {
        if (controller.ControllerType.Assembly == typeof(RoleController).Assembly)
            controller.ApiExplorer.GroupName = Prefix;
    }
}