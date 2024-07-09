// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

ServiceCollection services = new ServiceCollection();
services.AddLogging(options => options.AddConsole(options => { 
    options.IncludeScopes = true;
}));
ConfigurationBuilder configuration = new ConfigurationBuilder();
var conf = configuration.AddJsonFile("appsettings.json").Build();
services.AddSingleton<IConfiguration>(conf);

var sp = services.BuildServiceProvider();
var logger= sp.GetService<ILogger<string>>();

var logInformation = LoggerMessage.Define<string, int>(LogLevel.Information, new EventId(1), "Doing something with id {Id} and name {Name}");

var s_processingWorkScope =
    LoggerMessage.DefineScope<DateTime>(
        "Processing scope, started at: {DateTime}");

using (s_processingWorkScope(logger, DateTime.Now))
{
    logInformation(logger, "11", 1, null);
    await Task.Delay(1000);
    logInformation(logger, "11", 1, null);

}
