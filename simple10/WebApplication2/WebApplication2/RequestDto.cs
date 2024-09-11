using Microsoft.Extensions.ObjectPool;

namespace WebApplication2
{
    public class RequestDto : IResettable
    {
        public string Name { get; set; }

        public bool TryReset()
        {
            this.Name = null; 
            return true;
        }
    }
}
