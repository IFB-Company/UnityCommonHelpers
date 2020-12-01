using System.Collections.Generic;

namespace Common.ServiceLocator
{
    public class ServiceLocator
    {
        private ServiceLocator() {  }
        
        private readonly Dictionary<string, IGameService> _services = new Dictionary<string, IGameService>();
        
        public static ServiceLocator Current { get; private set; }
        
        public static void Initialize()
        {
            Current = new ServiceLocator();
        }

        public T Get<T>() where T : IGameService
        {
            string key = typeof(T).Name;

            return default(T);

        }
    }
}

