// See https://aka.ms/new-console-template for more information

using ConsoleApp3;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Dictionary<string, string> map = new Dictionary<string, string>() {
    {"-a","a"},
    {"--aa","a"},
    {"-b","b"},
    {"--bb","b"}
};

 await Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(config => {
        config.AddCommandLine(args, map);
    })
   .ConfigureServices(config =>
   {
       var serviceProvider= config.BuildServiceProvider();
       config.Configure<Person>(serviceProvider.GetService<IConfiguration>().GetSection("Person"));
       
       config.AddHostedService<DemoHostService>();
   })
   .ConfigureHostConfiguration(config =>
   {
   }).ConfigureAppConfiguration(config => {
       config.Add(new CustomConfigureSource());
   })
   .Build().RunAsync();