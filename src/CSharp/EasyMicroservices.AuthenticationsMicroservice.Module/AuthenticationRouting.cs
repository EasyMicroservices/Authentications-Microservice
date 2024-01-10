using EasyMicroservices.AuthenticationsMicroservice.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
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
                options.Conventions.Add(new RoutePrefixConvention(new RouteAttribute("authentication")));
            });
        }
        else
        {
            mvcBuilder = services.AddMvc();
        }
        mvcBuilder.AddApplicationPart(typeof(RoleController).Assembly);
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