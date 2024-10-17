using Microsoft.AspNetCore.Mvc;
using PirateTARpe23.Core.Domain;
using PirateTARpe23.Core.ServiceInterface;
using PirateTARpe23.Data;
using PirateTARpe23.Models.Pirates;

namespace PirateTARpe23.Controllers
{
    public class PirateController : Controller
    {
        private readonly PirateTARpe23Context _context;
        private readonly IPirateServices _pirateServices;

        public PirateController(PirateTARpe23Context context, IPirateServices pirateServices)
        {
            _context = context;
            _pirateServices = pirateServices;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.Pirates
                .OrderByDescending(y => y.Level)
                .Select(x => new PirateIndexViewModel
                {
                    ID = x.ID,

                    Name = x.Name,

                    Health = x.Health,

                    HungerLevel = x.HungerLevel,

                    ThirstLevel = x.ThirstLevel,

                    Level = x.Level,

                    XP = x.XP
                }
                );
            return View(result);
        }
    }
}
