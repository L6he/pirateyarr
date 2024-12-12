using Microsoft.AspNetCore.Mvc;
using PirateTARpe23.Core.Domain;
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

        //[HttpGet]
        //public async Task<PlayerProfile>
    }
}
