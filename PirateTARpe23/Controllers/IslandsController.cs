using Microsoft.AspNetCore.Mvc;
using PirateTARpe23.ApplicationServices.Services;
using PirateTARpe23.Core.Dto;
using PirateTARpe23.Core.ServiceInterface;
using PirateTARpe23.Data;
using PirateTARpe23.Models.Islands;
using PirateTARpe23.Models;

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
                .OrderByDescending(y => y.XPReward)
                .Select(x => new IslandIndexViewModel
                {
                    IslandID = x.IslandID,

                    IslandName = x.IslandName,

                    IsBigIsland = x.IsBigIsland,

                    IslandStatus = (Models.Islands.IslandStatus)x.IslandStatus,

                    LevelRequirement = x.LevelRequirement,

                    XPReward = x.XPReward
                }
                );
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            IslandCreateViewModel vm = new();
            return View("Create", vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IslandCreateViewModel vm)
        {
            var dto = new IslandDto()
            {
                IslandName = vm.IslandName,
                IsBigIsland = vm.IsBigIsland,
                IslandStatus = (Core.Dto.IslandStatus)vm.IslandStatus,
                LevelRequirement = vm.LevelRequirement,
                XPReward = vm.XPReward,
                Files = vm.Files,
                Image = vm.Image.Select(
                    x => new FileToDatabaseDto { ID = x.ID, ImageTitle = x.ImageTitle, ImageData = x.ImageData, IslandID = x.IslandID }
                    )
            };
            var result = await _islandsServices.Create(dto);
            if (result == null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", vm);
        }
    }
}
