using AutoMapper;
using ScrumRandomizerServer.Data.Logging;
using ScrumRandomizerServer.Data.Users.Models;

namespace ScrumRandomizerServer.Core.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ILogEntry, MongoLogEntry>().ReverseMap();
            CreateMap<IUser, MongoUser>().ReverseMap();
        }
    }
}