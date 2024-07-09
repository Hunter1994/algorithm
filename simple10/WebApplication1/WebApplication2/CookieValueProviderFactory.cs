using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApplication2
{
    public class CookieValueProviderFactory : IValueProviderFactory
    {
        public async  Task CreateValueProviderAsync(ValueProviderFactoryContext context)
        {
            context.ValueProviders.Add(new CookieValueProvider());
        }
    }
}
