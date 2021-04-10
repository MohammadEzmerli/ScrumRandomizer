using AutoMapper;
using MongoDB.Driver;
using ScrumRandomizerServer.Data.DbFactory;
using ScrumRandomizerServer.Data.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumRandomizerServer.Data.Users
{
    public class MongoUserRepository : IUserRepository
    {
        private readonly IMongoCollection<MongoUser> _users;
        private readonly IMapper _mapper;
        public MongoUserRepository(IServiceProvider serviceProvider)
        {
            _users = ((IMongoDbFactory)serviceProvider.GetService(typeof(IMongoDbFactory))).GetCollection<MongoUser>();
        }

        async Task<IUser> IUserRepository.Create(IUser user)
        {
            var mappedUser = _mapper.Map<MongoUser>(user);
            await _users.InsertOneAsync(mappedUser);
            return mappedUser;
        }

        async Task<bool> IUserRepository.Delete(IUser user)
        {
            var result = await _users.DeleteOneAsync(Builders<MongoUser>.Filter.Eq(nameof(IUser.Id), user.Id));
            return result.DeletedCount > 0;
        }

        async Task<bool> IUserRepository.Delete(Guid id)
        {
            var result = await _users.DeleteOneAsync(Builders<MongoUser>.Filter.Eq(nameof(IUser.Id), id));
            return result.DeletedCount > 0;
        }

        async Task<IEnumerable<IUser>> IUserRepository.GetAll()
        {
            var userTask = await _users.FindAsync(LogEntry => true);
            var userEntries = await userTask.ToListAsync();
            return userEntries.Cast<IUser>().ToList();
        }

        async Task<IUser> IUserRepository.GetById(Guid id)
        {
            var userTask = await _users.FindAsync(User => User.Id == id);
            return await userTask.FirstOrDefaultAsync();
        }

        async Task<IUser> IUserRepository.GetByName(string name)
        {
            var userTask = await _users.FindAsync(User => User.Name == name);
            return await userTask.FirstOrDefaultAsync();
        }

        async Task<IUser> IUserRepository.Update(IUser user)
        {
            var mappedUser = _mapper.Map<MongoUser>(user);
            var options = new FindOneAndReplaceOptions<MongoUser> { ReturnDocument = ReturnDocument.After };
            var updatedUser = await _users.FindOneAndReplaceAsync<MongoUser>(document =>
                document.Id == mappedUser.Id,
                mappedUser,
                options
            );
            return updatedUser;
        }
    }
}