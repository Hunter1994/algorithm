using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.WebHost.UseKestrel(options =>
{
    options.ConfigureHttpsDefaults(httpoptions =>
    {
        httpoptions.ServerCertificate = new X509Certificate2("certificate.pfx", "");
    });
    options.Limits.MaxRequestBodySize = 1;
});

var app = builder.Build();
app.UseHttpsRedirection();
app.MapGet("/", async () => {

    return "Hello World!";
});
app.MapControllers();
app.Run();
