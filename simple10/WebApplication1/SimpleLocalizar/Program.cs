using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.DependencyInjection;
using SimpleLocalizar;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddLocalization(options => {
    options.ResourcesPath = "Resources";
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.Configure<RouteDataRequestCultureProviderOptions>(options =>
//{
//    options.RouteDataKey = "culture"; // 路由数据中包含文化信息的键名
//});

//builder.Services.AddSingleton<IRequestCultureProvider, RouteDataRequestCultureProvider>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRequestLocalization(options =>
{
    var supportedCultures = new[] { "en-US", "zh-CN" };
    options.SetDefaultCulture(supportedCultures[0])
        .AddSupportedCultures(supportedCultures)
        .AddSupportedUICultures(supportedCultures);

    options.CultureInfoUseUserOverride = true;
    //options.AddInitialRequestCultureProvider(new CustomRequestCultureProvider(async context =>
    //{
    //    var currentCulture = "en";
    //    var segments = context.Request.Path.Value.Split(new char[] { '/' },
    //        StringSplitOptions.RemoveEmptyEntries);

    //        currentCulture = segments[0];

    //    var requestCulture = new ProviderCultureResult(currentCulture);

    //    return requestCulture;
    //}));
    //options.RequestCultureProviders.Add(new RouteDataRequestCultureProvider(new RouteDataRequestCultureProviderOptions()
    //{
    //    RouteDataKey = "culture"
    //}));
    //var questStringCultureProvider = options.RequestCultureProviders[3];
    //options.RequestCultureProviders.RemoveAt(0);
    //options.RequestCultureProviders.Insert(1, questStringCultureProvider);
});

//app.UseRequestLocalization();
app.UseAuthorization();

app.MapControllers();

app.Run();
