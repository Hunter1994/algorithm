using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication3;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => {
    }).AddGoogle(googleOptions =>
    {
        googleOptions.ClientId = "39744207345-60skmd77uoj7fp7v194p39019g5gj1s2.apps.googleusercontent.com";
        googleOptions.ClientSecret = "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";
    });
builder.Services.AddIdentityApiEndpoints<IdentityUser>(options => {
    //options.SignIn.RequireConfirmedEmail = true;
}).AddEntityFrameworkStores<DemoDbContext>();
builder.Services.AddAuthorization();
builder.Services.AddDbContext<DemoDbContext>(options => {
    options.UseSqlite("Data Source=demo.db");
});

builder.Services.AddSingleton<IEmailSender, Email>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapIdentityApi<IdentityUser>();

app.MapGet("/a", async Task ([FromServices] IServiceProvider sp) => {
    var signIn = sp.GetService<SignInManager<IdentityUser>>();

    var p = new AuthenticationProperties();
    p.Items.Add(new KeyValuePair<string, string?>("a", "a"));
    await signIn.SignInAsync(new IdentityUser() { UserName = "1" }, p);

});
app.MapGet("/b", async Task<string> ([FromServices] IServiceProvider sp,HttpContext context) => {
    var auth = await context.AuthenticateAsync();
    StringBuilder sb = new StringBuilder();
    sb.Append("Claims:");
    foreach (var item in context.User.Claims)
    {
        sb.Append($"Key:{item.Type} Value:{item.Value}£»");
    }
    sb.Append("Properties:");
    foreach (var item in auth?.Properties?.Items??new Dictionary<string,string>())
    {
        sb.Append($"Key:{item.Key} Value:{item.Value}£»");
    }
    return sb.ToString();
});

app.Run();
