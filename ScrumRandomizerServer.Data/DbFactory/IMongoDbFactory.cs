using MongoDB.Driver;

namespace ScrumRandomizerServer.Data.DbFactory
{
    public interface IMongoDbFactory
    {
        IMongoCollection<T> GetCollection<T>();
    }
}