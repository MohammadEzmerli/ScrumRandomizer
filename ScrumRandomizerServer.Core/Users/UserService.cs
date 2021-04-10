using ScrumRandomizerServer.Data.Users;
using ScrumRandomizerServer.Data.Users.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScrumRandomizerServer.Core.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IServiceProvider serviceProvider)
        {
            _userRepository = (IUserRepository)serviceProvider.GetService(typeof(IUserRepository));
        }

        async Task<IUser> IUserService.Create(IUser user)
        {
            IUser newUser = null;
            try
            {
                newUser = await _userRepository.Create(user);
            }
            catch (Exception ex)
            {
                Log.Error($"An error occured during '{nameof(IUserService.Create)}' in class '{nameof(UserService)}' -> {ex}");
            }
            return newUser
                ?? throw new NotImplementedException();
        }

        async Task<bool> IUserService.Delete(IUser user)
        {
            var result = false;
            try
            {
                result = await _userRepository.Delete(user);
            }
            catch (Exception ex)
            {
                Log.Error($"An error occured during '{nameof(IUserService.Delete)}' in class '{nameof(UserService)}' -> {ex}");
            }
            return result;
        }

        async Task<bool> IUserService.Delete(Guid id)
        {
            var result = false;
            try
            {
                result = await _userRepository.Delete(id);
            }
            catch (Exception ex)
            {
                Log.Error($"An error occured during '{nameof(IUserService.Delete)}' in class '{nameof(UserService)}' -> {ex}");
            }
            return result;
        }

        async Task<IEnumerable<IUser>> IUserService.GetAll()
        {
            IEnumerable<IUser> foundUsers = null;
            try
            {
                foundUsers = await _userRepository.GetAll();
            }
            catch (Exception ex)
            {
                Log.Error($"An error occured during '{nameof(IUserService.GetAll)}' in class '{nameof(UserService)}' -> {ex}");
            }
            return foundUsers
                ?? new List<IUser>();
        }

        async Task<IUser> IUserService.GetById(Guid id)
        {
            IUser foundUser = null;
            try
            {
                foundUser = await _userRepository.GetById(id);
            }
            catch (Exception ex)
            {
                Log.Error($"An error occured during '{nameof(IUserService.GetById)}' in class '{nameof(UserService)}' -> {ex}");
            }
            return foundUser
                ?? throw new NotImplementedException();
        }

        async Task<IUser> IUserService.GetByName(string name)
        {
            IUser foundUser = null;
            try
            {
                foundUser = await _userRepository.GetByName(name);
            }
            catch (Exception ex)
            {
                Log.Error($"An error occured during '{nameof(IUserService.GetByName)}' in class '{nameof(UserService)}' -> {ex}");
            }
            return foundUser
                ?? throw new NotImplementedException();
        }

        async Task<IUser> IUserService.Update(IUser user)
        {
            IUser foundUser = null;
            try
            {
                foundUser = await _userRepository.Update(user);
            }
            catch (Exception ex)
            {
                Log.Error($"An error occured during '{nameof(IUserService.Update)}' in class '{nameof(UserService)}' -> {ex}");
            }
            return foundUser
                ?? throw new NotImplementedException();
        }
    }
}