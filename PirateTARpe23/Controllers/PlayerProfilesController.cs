using Microsoft.AspNetCore.Mvc;
using PirateTARpe23.Core.Domain;
using PirateTARpe23.Core.Dto.AccountsDtos;
using PirateTARpe23.Data;
using System.Data.Entity.Core.Metadata.Edm;

namespace PirateTARpe23.Controllers
{
    public class PlayerProfilesController : Controller
    {
        private readonly PirateTARpe23Context _context;

        public PlayerProfilesController(PirateTARpe23Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(_context.PlayerProfiles.OrderByDescending(x => x.ScreenName));
        }

        [HttpGet]
        public async Task<IActionResult> NewProfile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewProfile(PlayerProfileDto dto)
        {
            if (dto.ApplicationUserID == Guid.Empty)
            {

                return View(Index);
            }

            var newProfile = new PlayerProfile()
            {
                ID = dto.ID,
                ApplicationUserID = dto.ApplicationUserID,
                ScreenName = "",
                dabloons = 100,
                epicfortnitevictoryroyales = 0,
                CurrentStatus = ProfileStatus.Active,
                IsAdmin = false
            };
            var result = await _context.PlayerProfiles.AddAsync(newProfile);
            if (result != null)
            {
                return View(Index);
            }

            return View();
        }
        //[HttpGet]
        //public async Task<PlayerProfile>
    }
}
