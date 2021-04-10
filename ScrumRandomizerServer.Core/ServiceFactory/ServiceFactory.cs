using ScrumRandomizerServer.Core.Logging;
using ScrumRandomizerServer.Core.Users;
using System;

namespace ScrumRandomizerServer.Core.ServiceFactory
{
    public static class ServiceFactory
    {
        public static T CreateService<T>(IServiceProvider serviceProvider) where T : class
        {
            if (typeof(T) == typeof(ILogService))
                return (T)(new LogService(serviceProvider) as ILogService);
            if (typeof(T) == typeof(IUserService))
                return (T)(new UserService(serviceProvider) as IUserService);
            else
                throw new NotImplementedException($"Service of type '{typeof(T)}' is not yet implemented!");
        }
    }
}