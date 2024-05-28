using WebApplication2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();
builder.Services.AddHealthChecks();
//builder.Services.Configure<CookiePolicyOptions>(options =>
//{
//    // This lambda determines whether user consent for non-essential 
//    // cookies is needed for a given request.
//    options.CheckConsentNeeded = context => true;

//    options.MinimumSameSitePolicy = SameSiteMode.None;
//    options.ConsentCookieValue = "true";

//});
builder.Services.AddSingleton<IServiceFactory, ServiceFactory>();

var app = builder.Build();

using (var service = app.Services.GetService<IServiceFactory>().CreateTransientService())
{
    service.SomeMethod();
}

    app.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Hello, World!");
    });

app.MapGet("/about", async context =>
{
    await context.Response.WriteAsync("About us page");
});


//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseCookiePolicy();

//app.UseRouting();

//app.UseAuthorization();

//app.MapRazorPages();




app.UseDemo();
app.MapHealthChecks("/a", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
{
    ResponseWriter = async (a, b) => await a.Response.WriteAsync("111")
});

app.Map("/", async context => {
    await context.Response.WriteAsync("aaaaaaaaaaaaa");
});

app.Run(async context => {
    Console.WriteLine("run1");
    await context.Response.WriteAsync("bbbbbbbbbbb");
    Console.WriteLine("run2");
});


app.Run();

