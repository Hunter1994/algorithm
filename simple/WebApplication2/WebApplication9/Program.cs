using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Polly;
using WebApplication9;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(
    TimeSpan.FromSeconds(10));
var longTimeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(
    TimeSpan.FromSeconds(30));

builder.Services.AddHttpClient("demo", configure =>
{
    configure.BaseAddress = new Uri("https://localhost:7001/");
}).AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.WaitAndRetryAsync(3, retryNumber => TimeSpan.FromMilliseconds(600)))
.AddPolicyHandler(httpRequestMessage =>
        httpRequestMessage.Method == HttpMethod.Get ? timeoutPolicy : longTimeoutPolicy);
//.AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.CircuitBreakerAsync(5, TimeSpan.FromSeconds(60)))
//.AddHeaderPropagation();

//builder.Services.AddHeaderPropagation(options => options.Headers.Add("X-TraceId"));



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument();
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
builder.Services.AddProblemDetails(options => {
    options.CustomizeProblemDetails = cts =>
    {
        cts.ProblemDetails.Extensions.Add("nodeId", Environment.MachineName);
    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{ 
    app.UseOpenApi();
    app.UseSwaggerUi();
}

//app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseStatusCodePages();

app.Use(async (context, next) =>
{
    Console.WriteLine("1");
    await next.Invoke();
});
app.Map("/a", async (HttpContext context, LinkGenerator linkGenerator, LinkParser linkParser) =>
{
    Console.WriteLine("a");
    var aa = linkGenerator.GetPathByAction("Get", "WeatherForecast");
    await context.Response.WriteAsync(aa);
}).ShortCircuit();

app.Map("/b", async (HttpContext context) =>
{
    Console.WriteLine("b");
    await context.Response.WriteAsync("b");
});

app.Use(async (context, next) =>
{
    Console.WriteLine("2");
    await next.Invoke();
});
//app.UseHeaderPropagation();
//app.MapShortCircuit(404, "aa", "bb");
app.UseStatusCodePages(Text.Plain, "Status Code Page: {0}");
app.Run();
