namespace WebApplication2
{
    public interface IService : IDisposable
    {
        void SomeMethod();
    }

    // 实现类
    public class TransientService : IService
    {
        public TransientService()
        {
            Console.WriteLine("TransientService instance created.");
        }

        public void SomeMethod()
        {
            Console.WriteLine("Doing something in TransientService.");
        }

        public void Dispose()
        {
            Console.WriteLine("TransientService disposed.");
        }
    }

    public interface IServiceFactory
    {
        IService CreateTransientService();
    }

    // 工厂类
    public class ServiceFactory: IServiceFactory
    {
        private IServiceProvider _serviceProvider;

        public ServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IService CreateTransientService()
        {
            //ActivatorUtilities.CreateInstance可以解决TransientService的依赖项问题
            return ActivatorUtilities.CreateInstance<TransientService>(_serviceProvider);
        }
    }
}
