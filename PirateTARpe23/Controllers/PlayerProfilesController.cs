using Microsoft.AspNetCore.Mvc;
using PirateTARpe23.Core.Domain;
using PirateTARpe23.Core.Dto.AccountsDtos;
using PirateTARpe23.Data;

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
            string userid = TempData["NewUserID"].ToString();
            if (userid == null)
            {

                return View(Index);
            }

            var newProfile = new PlayerProfile()
            {
                ID = dto.ID,
                ApplicationUserID = TempData["NewUserID"].ToString(),
                ScreenName = dto.ScreenName,
                Dabloons = 100,
                Epicfortnitevictoryroyales = 0,
                CurrentStatus = Core.Domain.ProfileStatus.Active,
                //IsAdmin = false
            };
            var result = await _context.PlayerProfiles.AddAsync(newProfile);
            await _context.SaveChangesAsync();
            if (result != null)
            {
                return View("~/Views/Accounts/Login.cshtml");
            }

            return View("~/Views/Home/Index.cshtml");
        }
        //[HttpGet]
        //public async Task<PlayerProfile>
    }
}
