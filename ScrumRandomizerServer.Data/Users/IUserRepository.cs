﻿using ScrumRandomizerServer.Data.Users.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScrumRandomizerServer.Data.Users
{
    public interface IUserRepository
    {
        Task<IEnumerable<IUser>> GetAll();
        Task<IUser> GetById(Guid id);
        Task<IUser> GetByName(string name);
        Task<IUser> Create(IUser user);
        Task<bool> Delete(IUser user);
        Task<bool> Delete(Guid id);
        Task<IUser> Update(IUser user);
    }
}