using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.ComponentModel.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ConsoleApp1;
using Microsoft.Extensions.Hosting;

var configure = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json").Build();

var host=Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) => {

    })
    .ConfigureServices(options =>
    {

        options.AddDbContext<EfDbContext>(options =>
        {
            options.UseMySql(configure.GetConnectionString("Default1"), new MySqlServerVersion("5.6"));
        });

    }).Build() ;

host.Run();