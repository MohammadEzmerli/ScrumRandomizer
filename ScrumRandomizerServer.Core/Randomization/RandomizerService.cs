using ScrumRandomizerServer.Data.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScrumRandomizerServer.Core.Randomization
{
    public class RandomizerService : IRandomizerService
    {
        public List<IUser> RandomizeUsers(List<IUser> users)
        {
            Random random = new Random();
            return users.OrderBy(p => random.Next()).ToList();
        }
    }
}