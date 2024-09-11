using Microsoft.EntityFrameworkCore;
using WebApplication3.Domain;

namespace WebApplication3
{
    public class WeatherForecastScopedFactory : IDbContextFactory<EFDbContext>
    {
        private const int DefaultTenantId = -1;

        private readonly IDbContextFactory<EFDbContext> _pooledFactory;
        private readonly int _tenantId;

        public WeatherForecastScopedFactory(
            IDbContextFactory<EFDbContext> pooledFactory,
            ITenantId tenant)
        {
            _pooledFactory = pooledFactory;
            _tenantId = tenant?.Id ?? DefaultTenantId;
        }

        public EFDbContext CreateDbContext()
        {
            var context = _pooledFactory.CreateDbContext();
            context.TenantId = new TenantId(_tenantId);
            return context;
        }
    }
}
