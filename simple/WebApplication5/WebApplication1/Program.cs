using Microsoft.AspNetCore.Server.Kestrel.Core;
using Serilog.Events;
using Serilog;
using System.Net;
using WebApplication1;
Log.Logger = new LoggerConfiguration()
#if DEBUG
        .MinimumLevel.Debug()
#else
            .MinimumLevel.Information()
#endif
        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
        .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Debug)
        .MinimumLevel.Override("Volo.Abp.Swashbuckle", LogEventLevel.Debug)
        .Enrich.FromLogContext()
        .WriteTo.Async(c => c.File("Logs/logs.txt"))
        .WriteTo.Async(c => c.Console())
        .CreateLogger();
var builder = WebApplication.CreateBuilder(args);
builder.Host.AddAppSettingsSecretsJson().UseAutofac().UseSerilog();
await builder.Services.AddApplicationAsync<WebApplication1Module>();


var app = builder.Build();
await app.InitializeApplicationAsync();
await app.RunAsync();

////builder.WebHost.UseHttpSys(options =>
////{
////    options.AllowSynchronousIO = false;
////    options.Authentication.AllowAnonymous = true;
////    options.MaxConnections = null;
////    options.MaxRequestBodySize = 30_000_000;
////    options.UrlPrefixes.Add("http://localhost:5005");
////});
////builder.WebHost.UseKestrel(options => {
////    options.ListenLocalhost(5100);
////});

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
////if (app.Environment.IsDevelopment())
////{
//    app.UseSwagger();
//    app.UseSwaggerUI();
////}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
