using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Acme.MyMauiApp;

[DependsOn(typeof(AbpAutofacModule))]
public class MyMauiAppModule : AbpModule
{
}
