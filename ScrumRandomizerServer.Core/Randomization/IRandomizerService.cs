using ScrumRandomizerServer.Data.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumRandomizerServer.Core.Randomization
{
    public interface IRandomizerService
    {
        List<IUser> RandomizeUsers(List<IUser> users);
    }
}