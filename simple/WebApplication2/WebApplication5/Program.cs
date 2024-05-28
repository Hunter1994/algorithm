using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ConfigureHttpsDefaults(httpsOptions =>
    {
        var certificate = new X509Certificate2("certificate.pfx", "", X509KeyStorageFlags.Exportable);
        httpsOptions.ServerCertificate = certificate;
    });
});

var aa= builder.Configuration.Sources;

var queue = new PriorityQueue<(int, int), int>();

var app = builder.Build();
app.UseHsts();
app.Urls.Add("https://localhost:3000");
Console.WriteLine($"Application Name: {builder.Environment.ApplicationName}");
Console.WriteLine($"Environment Name: {builder.Environment.EnvironmentName}");
Console.WriteLine($"ContentRoot Path: {builder.Environment.ContentRootPath}");
Console.WriteLine($"WebRootPath: {builder.Environment.WebRootPath}");
app.MapGet("/", () => "Hello World");
app.MapGet("/aa", () => "Hello World");
app.MapGet("/bb", async (IServiceProvider service, HttpContext context) =>
{
    var bb = service.GetService<IConfiguration>()["BB"];
    await context.Response.WriteAsync(bb);
});

app.Run();


//using WebApplication5;

//var host = Host.CreateDefaultBuilder(args);
//host.ConfigureAppConfiguration(config =>
//{

//});
//host.ConfigureHostConfiguration(config =>
//{

//});
//host.ConfigureWebHostDefaults(webBuilder =>
//{
//    webBuilder.UseUrls("https://localhost:3000");
//    webBuilder.UseStartup<Startup>();
//});
//await host.Build().RunAsync();
