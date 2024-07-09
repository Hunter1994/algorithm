using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApplication2
{
    public class CookieValueProvider : IValueProvider
    {
        public bool ContainsPrefix(string prefix)
        {
            throw new NotImplementedException();
        }

        public ValueProviderResult GetValue(string key)
        {
            throw new NotImplementedException();
        }
    }
}
