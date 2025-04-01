using Microsoft.AspNetCore.Mvc;
using PirateTARpe23.ApplicationServices.Services;
using PirateTARpe23.Core.Dto;
using PirateTARpe23.Core.ServiceInterface;
using PirateTARpe23.Data;
using PirateTARpe23.Models.Islands;
using PirateTARpe23.Models;
using PirateTARpe23.Models.Pirates;
using PirateTARpe23.Core.Domain;
using Microsoft.EntityFrameworkCore;
using PirateTARpe23.Models.Stories;

namespace PirateTARpe23.Controllers
{
    public class IslandsController : Controller
    {
        private readonly PirateTARpe23Context _context;
        private readonly IIslandsServices _islandsServices;
        public IslandsController(PirateTARpe23Context context, IIslandsServices islandsServices)
        {
            _context = context;
            _islandsServices = islandsServices;
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
            };
            var result = await _islandsServices.Create(dto);
            if (result == null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid Id)
        {
            var island = await _islandsServices.DetailsAsync(Id);
            if (island == null)
            {
                return NotFound(); // Custom partial view
            }
            var vm = new IslandDetailsViewModel();
            vm.IslandID = island.IslandID;
            vm.IslandName = island.IslandName;
            vm.IsBigIsland = island.IsBigIsland;
            vm.IslandStatus = (Models.Islands.IslandStatus)island.IslandStatus;
            vm.LevelRequirement = island.LevelRequirement;
            vm.XPReward = island.XPReward;
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            if (id == null) { return NotFound(); }

            var island = await _islandsServices.DetailsAsync(id);

            if (island == null) { return NotFound(); }

            var vm = new IslandCreateViewModel();

            vm.IslandID = island.IslandID;

            vm.IslandName = island.IslandName;

            vm.IsBigIsland = island.IsBigIsland;
            vm.IslandStatus = (Models.Islands.IslandStatus)island.IslandStatus;
            vm.LevelRequirement = island.LevelRequirement; 
            vm.XPReward = (int)island.XPReward; //change

            return View("Update", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(IslandCreateViewModel vm)
        {
            //var dto = new IslandDto()
            //{
            //    IslandID = (Guid)vm.IslandID,

            //    IslandName = vm.IslandName,
            //    IsBigIsland = vm.IsBigIsland,

            //    IslandStatus = (Core.Dto.IslandStatus)vm.IslandStatus,
            //    LevelRequirement = vm.LevelRequirement,
            //    XPReward = vm.XPReward,
            //};
            var dto = new IslandDto();
            dto.IslandID = (Guid)vm.IslandID;

            dto.IslandName = vm.IslandName;
            dto.IsBigIsland = vm.IsBigIsland;
            dto.IslandStatus = (Core.Dto.IslandStatus)vm.IslandStatus;
            dto.LevelRequirement = vm.LevelRequirement;
            dto.XPReward = vm.XPReward;
            
            var result = await _islandsServices.Update(dto);

            if (result == null) { return RedirectToAction("Index"); }
            return RedirectToAction("Index", vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null) { return NotFound(); }

            var island = await _islandsServices.DetailsAsync(id);

            if (island == null) { NotFound(); }

            var vm = new IslandDeleteViewModel();

            vm.IslandID = island.IslandID;

            vm.IslandName = island.IslandName;

            vm.IsBigIsland = island.IsBigIsland;
            vm.IslandStatus = (Models.Islands.IslandStatus)island.IslandStatus;
            vm.LevelRequirement = island.LevelRequirement;

            vm.XPReward = island.XPReward;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var islandToDelete = await _islandsServices.Delete(id);

            if (islandToDelete == null) { return RedirectToAction("Index"); }

            return RedirectToAction("Index");
        }
    }
}
