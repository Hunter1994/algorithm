using Volo.Abp.DependencyInjection;

namespace Acme.MyMauiApp;

public class HelloWorldService : ITransientDependency
{
    public string SayHello()
    {
        return "Hello, World!";
    }
}