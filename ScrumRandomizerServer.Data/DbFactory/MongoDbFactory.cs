using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Linq;

namespace ScrumRandomizerServer.Data.DbFactory
{
    public class MongoDbFactory : IMongoDbFactory
    {
        private readonly IConfiguration _configuration;

        public MongoDbFactory(IServiceProvider serviceProvider)
        {
            _configuration = (IConfiguration)serviceProvider.GetService(typeof(IConfiguration));
        }

        IMongoCollection<T> IMongoDbFactory.GetCollection<T>()
        {
            var client = new MongoClient(_configuration.GetConnectionString(Data.Configuration.Constants.DatabaseConnectionStringName));
            var database = client.GetDatabase(_configuration.GetSection(Data.Configuration.Constants.DatabaseName).Value);
            return database.GetCollection<T>(typeof(T).GetInterfaces().FirstOrDefault()?.Name ?? typeof(T).Name);
        }
    }
}