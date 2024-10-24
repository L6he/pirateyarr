using Microsoft.AspNetCore.Mvc;
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
        private readonly IPirateServices _pirateServices;

        public PiratesController(PirateTARpe23Context context, IPirateServices pirateServices)
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
        /*
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
                return RedirectToAction("Index", vm);
            }
        } */
    }
}
