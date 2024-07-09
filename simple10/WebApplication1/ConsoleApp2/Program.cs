using ConsoleApp2;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using System.ComponentModel.Design;

ConfigurationBuilder configuration = new ConfigurationBuilder();
configuration.AddJsonFile("appsettings.json", false, true);
var conf=configuration.Build();
ServiceCollection services = new ServiceCollection();
services.AddSingleton<IConfiguration>(conf);
services.AddMemoryCache();

var sp=services.BuildServiceProvider();

var fileContextCache= sp.GetService<IMemoryCache>();

while (true)
{
    Console.ReadLine();
    var aa =await GetCacheFileContext("appsettings.json");
    Console.WriteLine(aa);
}


async Task<string> GetCacheFileContext(string filename)
{
    if (fileContextCache.TryGetValue(filename, out string content))
    {
        return content;
    }
    var data =await GetFileContent(filename);
    if (data != null)
    {
        var changeToken = conf.GetReloadToken();
        var options = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromSeconds(60))
            .AddExpirationToken(changeToken);
        fileContextCache.Set(filename, data, options);
    }
    return data;
}

async Task<string> GetFileContent(string filePath)
{
    var runCount = 1;

    while (runCount < 4)
    {
        try
        {
            if (File.Exists(filePath))
            {
                using (var fileStreamReader = File.OpenText(filePath))
                {
                    return await fileStreamReader.ReadToEndAsync();
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
        catch (IOException ex)
        {
            if (runCount == 3)
            {
                throw;
            }

            Thread.Sleep(TimeSpan.FromSeconds(Math.Pow(2, runCount)));
            runCount++;
        }
    }

    return null;
}