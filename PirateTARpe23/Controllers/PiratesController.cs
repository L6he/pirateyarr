using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PirateTARpe23.Core.Domain;
using PirateTARpe23.Core.Dto;
using PirateTARpe23.Core.ServiceInterface;
using PirateTARpe23.Data;
using PirateTARpe23.Models.Pirates;
using System.Security.Cryptography.Xml;

namespace PirateTARpe23.Controllers
{
    public class PiratesController : Controller
    {
        private readonly PirateTARpe23Context _context;
        private readonly IPiratesServices _pirateServices;

        public PiratesController(PirateTARpe23Context context, IPiratesServices pirateServices)
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

        [HttpGet]
        public IActionResult Create() 
        {
            PirateCreateViewModel vm = new();
            return View("Create", vm);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(PirateCreateViewModel vm)
        {
            var dto = new PirateDto()
            {
                Name = vm.Name,

                Health = 200,

                HungerLevel = 0,

                ThirstLevel = 0,

                Level = 0,

                XP = 0,

                StatusEffect = (Core.Dto.StatusEffect)vm.StatusEffect,

                Files = vm.Files,

                Image = vm.Image.Select(x => new FileToDatabaseDto
                {
                    ID = x.ImageID,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    PirateID = x.PirateID,
                }
                ).ToArray()
            };
            var result = await _pirateServices.Create(dto);

            if (result != null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id /*, Guid ref*/)
        {
            var pirate = await _pirateServices.DetailsAsync(id);

            if (pirate == null) { return NotFound(); }

            var images = await _context.FilesToDatabase
                .Where(p => p.PirateID == id)
                .Select(y => new PirateImageViewModel
            {
                PirateID = y.ID,
                ImageID = y.ID,
                ImageData = y.ImageData,
                ImageTitle = y.ImageTitle,
                Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
            }).ToArrayAsync();

            var vm = new PirateDetailsViewModel();
            vm.ID = pirate.ID;
            vm.Name = pirate.Name;
            vm.Health = pirate.Health;
            vm.XP = pirate.XP;
            vm.Level = pirate.Level;
            vm.HungerLevel = pirate.HungerLevel;
            vm.ThirstLevel = pirate.ThirstLevel;
            vm.StatusEffect = (Models.Pirates.StatusEffect)pirate.StatusEffect;
            vm.PrimaryWeapon = (Models.Pirates.PrimaryWeapon)pirate.PrimaryWeapon;
            vm.SecondaryWeapon = (Models.Pirates.SecondaryWeapon)pirate.SecondaryWeapon;
            vm.Item = pirate.Item;
            vm.Image.AddRange(images);

            return View(vm);
        }
    }
}
