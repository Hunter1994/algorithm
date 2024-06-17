using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args).ConfigureHostConfiguration(config => {
    config.AddUserSecrets<Program>();
}).Build();

var user = host.Services.GetService<IConfiguration>()["user"];
Console.WriteLine(user);

host.Run();