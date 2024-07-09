using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var sp=builder.Services.BuildServiceProvider();
var aa = sp.GetService<IWebHostEnvironment>().ContentRootFileProvider;
var b= aa.GetFileInfo("appsettings.json");
var b2= aa.GetFileInfo("favicon.ico");
Console.WriteLine(b.Name);

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

app.MapRazorPages();

app.Run();
