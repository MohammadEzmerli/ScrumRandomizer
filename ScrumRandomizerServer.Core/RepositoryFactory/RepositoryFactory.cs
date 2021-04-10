using ScrumRandomizerServer.Data.DbFactory;
using ScrumRandomizerServer.Data.Logging;
using System;

namespace ScrumRandomizerServer.Core.RepositoryFactory
{
    public static class RepositoryFactory
    {
        public static T CreateRepository<T>(IServiceProvider serviceProvider) where T : class
        {
            if (typeof(T) is ILogRepository)
                return (T)(new LogRepository(serviceProvider) as ILogRepository);
            else if (typeof(T) is IMongoDbFactory)
                return (T)(new MongoDbFactory(serviceProvider) as IMongoDbFactory);
            else
                        throw new NotImplementedException($"Repository of type '{typeof(T)}' is not yet implemented!");
        }
    }
}
