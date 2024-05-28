using Microsoft.Extensions.Hosting;
using System.Net.Http;

public class DemoHost : IHostedService
{
    private IHttpClientFactory _httpClientFactory;

    public DemoHost(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var res = await _httpClientFactory.CreateClient("CertificateAuthentication").GetAsync("/info");
        var data = await res.Content.ReadAsStringAsync();
        Console.WriteLine(data);//输出：CN=localhost
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
    }
}