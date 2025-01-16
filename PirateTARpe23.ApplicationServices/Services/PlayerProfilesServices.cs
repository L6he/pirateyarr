using Microsoft.AspNetCore.Identity;
using PirateTARpe23.Core.Domain;
using PirateTARpe23.Core.ServiceInterface;

namespace PirateTARpe23.ApplicationServices.Services
{
    public class PlayerProfilesServices : IPlayerProfilesServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAccountsServices _accountsServices;

        public PlayerProfilesServices(UserManager<ApplicationUser> userManager, IAccountsServices accountsServices)
        {
            _userManager = userManager;
            _accountsServices = accountsServices;
        }

        public async Task<PlayerProfile> Create(string userIdFor)
        {
            var user = await _userManager.FindByIdAsync(userIdFor);
            string userId = user.Id;
            var profile = new PlayerProfile()
            {
                ID = new Guid(),
                ApplicationUserID = userId,
                ScreenName = "",
                dabloons = 100,
                epicfortnitevictoryroyales = 0,
                CurrentStatus = ProfileStatus.Active,
                IsAdmin = false
            };
            return profile;
            //var resultForProfile = await _playerProfilesServices.Create(profile);
        }
    }
}
