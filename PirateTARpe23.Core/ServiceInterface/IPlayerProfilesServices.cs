using PirateTARpe23.Core.Domain;

namespace PirateTARpe23.ApplicationServices.Services
{
    public interface IPlayerProfilesServices
    {
        Task<PlayerProfile> Create(string userIdFor);
    }
}