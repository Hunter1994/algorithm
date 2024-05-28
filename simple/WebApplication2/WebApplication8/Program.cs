using Microsoft.AspNetCore.Http;
using OpenTelemetry.Metrics;
using System.Net.Http;
using WebApplication8;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenTelemetry()
    .WithMetrics(builder =>
    {
        builder.AddPrometheusExporter();

        builder.AddMeter("Microsoft.AspNetCore.Hosting",
                         "Microsoft.AspNetCore.Server.Kestrel", "aspnetcore.rate_limiting.requests");
        builder.AddView("http.server.request.duration",
            new ExplicitBucketHistogramConfiguration
            {
                Boundaries = new double[] { 0, 0.005, 0.01, 0.025, 0.05,
                       0.075, 0.1, 0.25, 0.5, 0.75, 1, 2.5, 5, 7.5, 10 }
            });
    });
builder.Services.AddControllers();
builder.Services.AddRouting(options => {
    options.ConstraintMap["slugify"] = typeof(SlugifyParameterTransformer);
});


var app = builder.Build();
app.UseHttpMethodOverride();
app.UseRouting();
app.MapShortCircuit(404, "aa");

//app.Use(async (context, next) =>
//{
//    var _linkGenerator= context.RequestServices.GetService<LinkGenerator>();
//    if (context.GetEndpoint()?.Metadata.GetMetadata<RequiresAuditAttribute>() is not null)
//    {
//        Console.WriteLine($"ACCESS TO SENSITIVE DATA AT: {DateTime.UtcNow}");
//    }
//    var productsPath = _linkGenerator.GetUriByAction(action: "Get", "WeatherForecast", null, "https", new HostString("localhost",7178));
//    await context.Response.WriteAsync(
//          $"Go to {productsPath} to see our products.");
//    return;
//    await next(context);
//});

app.Use(async (context, next) =>
{
    Console.WriteLine("1");
    await next.Invoke();
});
app.Map("/a", async (HttpContext context, LinkGenerator linkGenerator, LinkParser linkParser) =>
{
    var aa = linkGenerator.GetPathByAction("Get", "WeatherForecast");
    await context.Response.WriteAsync(aa);
}).ShortCircuit();


app.Use(async (context, next) =>
{
    Console.WriteLine("2");
    await next.Invoke();
});
app.MapGet("/", () => "Audit isn't required.");
app.MapGet("/sensitive", () => "Audit required for sensitive data.")
    .WithMetadata(new RequiresAuditAttribute());

app.MapControllers();

app.Run();


