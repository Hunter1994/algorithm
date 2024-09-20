using Consul;

namespace WebApplication2
{
    public class ServiceDiscoveryClient
    {
        private readonly IConsulClient _consulClient;
        public ServiceDiscoveryClient(IConsulClient consulClient)
        {
            _consulClient = consulClient;
        }

        public async Task<IEnumerable<AgentService>> GetServicesAsync()
        {
            var services = await _consulClient.Agent.Services();
            return services.Response.Values;
        }

    }
}
