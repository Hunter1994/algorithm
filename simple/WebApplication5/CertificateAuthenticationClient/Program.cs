using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Http;
using System.Security.Cryptography.X509Certificates;
using System;

var build= Host.CreateDefaultBuilder(args);
var clientCertificate =
new X509Certificate2("root_ca_dev_damienbod.pfx", "1234");

build.ConfigureServices(service => {
    service.AddHostedService<DemoHost>();
    service.AddHttpClient("CertificateAuthentication", options => {
        options.BaseAddress = new Uri("https://localhost:7222");
    })
    .ConfigurePrimaryHttpMessageHandler(() =>
    {
        var handler = new HttpClientHandler();
        handler.ClientCertificates.Add(clientCertificate);
        return handler;
    });
}).ConfigureAppConfiguration(options => {
}).ConfigureHostConfiguration(options => { 
});

await build.RunConsoleAsync();
