using Microsoft.AspNetCore.Localization;
using OrchardCore.Localization;
using StringLocalizerDemo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMemoryCache();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddPortableObjectLocalization(options =>
//{
//    options.ResourcesPath = "Resources";
//});
builder.Services.AddLocalization(options => {
    options.ResourcesPath = "Resources";
});

//https://localhost:7167/WeatherForecast/get2?culture=es-MX&ui-culture=es-MX
//culture参数的值必须在supportedCultures列表中
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { "en-US", "fr" , "zh-CN" };
    options.SetDefaultCulture(supportedCultures[0])
        .AddSupportedCultures(supportedCultures)
        .AddSupportedUICultures(supportedCultures);
});

// 注册自定义的 IRequestCultureProvider
builder.Services.Configure<CustomRequestCultureOptions>(options =>
{
    options.DefaultCulture = "en-US"; // 默认文化
    options.DefaultUICulture = "en-US"; // 默认 UI 文化
});

builder.Services.AddSingleton<IRequestCultureProvider, CustomRequestCultureProvider2>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRequestLocalization(options =>
{
    options.CultureInfoUseUserOverride = true;
    //options.AddInitialRequestCultureProvider(new CustomRequestCultureProvider(async context =>
    //{
    //    var currentCulture = "en";
    //    var segments = context.Request.Path.Value.Split(new char[] { '/' },
    //        StringSplitOptions.RemoveEmptyEntries);
    //    //context.Request.RouteValues[""]
    //    if (segments.Length > 1)
    //    {
    //        currentCulture = segments[0];
    //    }

    //    //var requestCulture = new ProviderCultureResult(currentCulture);
    //    var requestCulture = new ProviderCultureResult("en-US");

    //    return requestCulture;
    //}));
});

//app.UseRequestLocalization();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
