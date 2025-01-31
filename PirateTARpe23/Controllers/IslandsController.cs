using Microsoft.AspNetCore.Mvc;
using PirateTARpe23.ApplicationServices.Services;
using PirateTARpe23.Core.ServiceInterface;
using PirateTARpe23.Data;
using PirateTARpe23.Models.Islands;
using PirateTARpe23.Models.Pirates;

namespace PirateTARpe23.Controllers
{
    public class IslandsController : Controller
    {
        private readonly PirateTARpe23Context _context;
        private readonly IIslandsServices _islandsServices;
        private readonly IFileServices _fileServices;
        public IslandsController(PirateTARpe23Context context, IIslandsServices islandsServices, IFileServices fileServices)
        {
            _context = context;
            _islandsServices = islandsServices;
            _fileServices = fileServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.Islands
                .OrderByDescending(y => y.IslandSize)
                .Select(x => new IslandIndexViewModel
                {
                    IslandID = x.IslandID,

                    IslandName = x.IslandName,

                    IslandSize = (Models.Islands.IslandSize)x.IslandSize,

                    IslandStatus = x.IslandStatus,

                    LevelRequirement = x.LevelRequirement,

                    XPReward = x.XPReward
                }
                );
            return View(result);
        }
    }
}
