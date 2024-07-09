using WorkerService1;

var builder = Host.CreateApplicationBuilder(args);
//builder.Services.AddHostedService<Worker>();
//builder.Services.AddHostedService<Worker>();
//builder.Services.AddHostedService<Worker1>();
builder.Services.AddLogging(options => {
    options.AddConsole();
});

builder.Services.AddSingleton<MonitorLoop>();
builder.Services.AddHostedService<QueuedHostedService>();
builder.Services.AddSingleton<IBackgroundTaskQueue>(ctx =>
{
    if (!int.TryParse(builder.Configuration["QueueCapacity"], out var queueCapacity))
        queueCapacity = 100;
    return new BackgroundTaskQueue(queueCapacity);
});

//var sp = builder.Services.BuildServiceProvider();
//var monitorLoop = sp.GetRequiredService<MonitorLoop>();
//monitorLoop.StartMonitorLoop();


var host = builder.Build();

host.Services.GetService<MonitorLoop>().StartMonitorLoop();


host.Run();
