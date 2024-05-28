namespace WebApplication5
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
            app.Map("/bb", build =>
            {

                build.Use(async (HttpContext context, RequestDelegate _next) =>
                {
                    var bb = context.RequestServices.GetService<IConfiguration>()["BB"];
                    await context.Response.WriteAsync(bb);
                });
            });
        }
    }
}
