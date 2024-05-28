using AspNet.Security.OAuth.GitHub;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApplication2;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.EventsType = typeof(CustomCookieAuthenticationEvents);
        options.ForwardDefaultSelector = ctx => ctx.Request.Path.StartsWithSegments("/api") ? GitHubAuthenticationDefaults.AuthenticationScheme : null;
    }).AddGoogle(googleOptions =>
    {
        googleOptions.ClientId = "39744207345-60skmd77uoj7fp7v194p39019g5gj1s2.apps.googleusercontent.com";
        googleOptions.ClientSecret = "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";
        googleOptions.ClaimActions.MapJsonKey("urn:google:picture", "picture", "url");
        googleOptions.ClaimActions.MapJsonKey("urn:google:locale", "locale", "string");

    }).AddGitHub(options => {
        options.ClientId = "Ov23lis2vLqhdL0nM9hd";
        options.ClientSecret = "037f74d304a44faddc3dc477f612371e87be3c35";
    });
builder.Services.AddScoped<CustomCookieAuthenticationEvents>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<DemoDbContext>().AddDefaultUI();
builder.Services.AddAuthorization();
builder.Services.AddDbContext<DemoDbContext>(options => {
    options.UseSqlite("Data Source=demo.db");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization(); 
app.UseAuthorization();

app.MapRazorPages();

app.MapGet("/login", async Task (HttpContext context) =>
{
    ClaimsIdentity claimsIdentity = new ClaimsIdentity(new List<Claim>() { new Claim(ClaimTypes.Name, "000@qq.com") }, CookieAuthenticationDefaults.AuthenticationScheme);
    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

    if (!Redis.Tokens.Contains(claimsPrincipal.Identity.Name))
        Redis.Tokens.Add(claimsPrincipal.Identity.Name);//模拟缓存token到redis

    await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties()
    {
        //浏览器关闭后仍然保留相应的 cookie
        IsPersistent = true,
        //设置绝对过期时间
        ExpiresUtc = DateTime.UtcNow.AddMinutes(20)
    });
});

app.MapGet("/info", async Task<string> (HttpContext context) =>
{
    return context.User.Identity.Name ?? "";
}).RequireAuthorization(options =>
{
    options.RequireClaim(ClaimTypes.Name);
    options.AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme);
});

app.MapGet("/api/info", async Task<string> (HttpContext context) =>
{
    return context.User.Identity.Name ?? "";
}).RequireAuthorization(options =>
{
    options.RequireClaim(ClaimTypes.Name);
    options.AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme);
});

app.MapGet("/stop", async Task (HttpContext context) => {
    var name = context.User.Identity.Name ?? "";
    Redis.Tokens.Remove(name);
});


app.Run();
