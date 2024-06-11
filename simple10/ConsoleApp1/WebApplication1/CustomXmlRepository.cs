using Microsoft.AspNetCore.DataProtection.Repositories;
using System.Xml.Linq;

namespace WebApplication1
{
    public class CustomXmlRepository : IXmlRepository
    {
        private readonly IServiceScopeFactory factory;
        public CustomXmlRepository(IServiceScopeFactory factory)
        {
            this.factory = factory;
        }
        public IReadOnlyCollection<XElement> GetAllElements()
        {
            using (var scope = factory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<WebApplication1DbContext>();
                var keys = context.XmlKeys.ToList()
                    .Select(x => XElement.Parse(x.Xml))
                    .ToList();
                return keys;
            }
        }
        public void StoreElement(XElement element, string friendlyName)
        {
            var key = new XmlKey
            {
                Xml = element.ToString(SaveOptions.DisableFormatting)
            };
            using (var scope = factory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<WebApplication1DbContext>();
                context.XmlKeys.Add(key);
                context.SaveChanges();
            }
        }
    }
}
