using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

namespace StringLocalizerDemo
{
    public class CustomRequestCultureProvider2 : IRequestCultureProvider
    {
        private readonly ILogger<CustomRequestCultureProvider2> _logger;
        private readonly CustomRequestCultureOptions _options;

        public CustomRequestCultureProvider2(
            IOptions<CustomRequestCultureOptions> options,
            ILogger<CustomRequestCultureProvider2> logger)
        {
            _options = options.Value;
            _logger = logger;
        }

        public Task<ProviderCultureResult?> DetermineProviderCultureResult(HttpContext httpContext)
        {
            try
            {
                // 在这里根据自定义的逻辑来确定请求的文化
                var culture = _options.DefaultCulture;
                var uiCulture = _options.DefaultUICulture;

                // 根据请求、用户、或其他信息自定义设置 culture 和 uiCulture
                // 例如，从请求的头部、用户首选项等获取文化信息

                // 这里简单示例为直接从查询参数中获取文化信息
                var queryCulture = httpContext.Request.RouteValues["culture"].ToString();
                if (!string.IsNullOrEmpty(queryCulture))
                {
                    culture = queryCulture.ToString();
                    uiCulture = culture; // UI culture 可能需要独立设置
                }

                // 返回 ProviderCultureResult 对象
                var providerResult = new ProviderCultureResult(culture, uiCulture);
                return Task.FromResult<ProviderCultureResult?>(providerResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error determining culture information.");
                return Task.FromResult<ProviderCultureResult?>(null);
            }
        }
    }

    public class CustomRequestCultureOptions
    {
        public string DefaultCulture { get; set; }
        public string DefaultUICulture { get; set; }
    }
}
