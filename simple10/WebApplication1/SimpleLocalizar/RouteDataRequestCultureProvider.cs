using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

namespace SimpleLocalizar
{
    public class RouteDataRequestCultureProvider : IRequestCultureProvider
    {
        public readonly RouteDataRequestCultureProviderOptions _options;

        public RouteDataRequestCultureProvider(
            RouteDataRequestCultureProviderOptions options)
        {
            _options = options;
        }

        public Task<ProviderCultureResult?> DetermineProviderCultureResult(HttpContext httpContext)
        {
            try
            {
                var routeValues = httpContext.GetRouteData()?.Values;
                if (routeValues != null && routeValues.ContainsKey(_options.RouteDataKey))
                {
                    var culture = routeValues[_options.RouteDataKey]?.ToString();
                    var providerResult = new ProviderCultureResult(culture);

                    return Task.FromResult<ProviderCultureResult?>(providerResult);
                }

                // If no culture found in route data, return null
                return Task.FromResult<ProviderCultureResult?>(null);
            }
            catch (Exception ex)
            {
                return Task.FromResult<ProviderCultureResult?>(null);
            }
        }
    }

    public class RouteDataRequestCultureProviderOptions
    {
        public string RouteDataKey { get; set; }
    }
}
