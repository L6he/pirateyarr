using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using PirateTARpe23.ApplicationServices.Services;
using PirateTARpe23.Core.Domain;
using PirateTARpe23.Core.Dto;
using PirateTARpe23.Core.ServiceInterface;
using PirateTARpe23.Data;
using PirateTARpe23.Models.Pirates;
using PirateTARpe23.Models.Stories;
using System.Security.Cryptography.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace PirateTARpe23.Controllers
{
    public class PiratesController : Controller
    {
        private readonly PirateTARpe23Context _context;
        private readonly IPiratesServices _piratesServices;
        private readonly IFileServices _fileServices;

        public PiratesController(PirateTARpe23Context context, IPiratesServices pirateServices, IFileServices fileServices)
        {
            _context = context;
            _piratesServices = pirateServices;
            _fileServices = fileServices;
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

                PrimaryWeapon = (Core.Dto.PrimaryWeapon)vm.PrimaryWeapon,

                SecondaryWeapon = (Core.Dto.SecondaryWeapon)vm.SecondaryWeapon,

                Item = (Core.Dto.Item)vm.Item,

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
            var result = await _piratesServices.Create(dto);

            if (result != null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id /*, Guid ref*/)
        {
            var pirate = await _piratesServices.DetailsAsync(id);

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
            vm.Item = (Models.Pirates.Item)pirate.Item;
            vm.Image.AddRange(images);

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            if (id == null) { return NotFound(); }

            var pirate = await _piratesServices.DetailsAsync(id);

            if (pirate == null) { return NotFound(); }

            var images = await _context.FilesToDatabase
                .Where(x => x.PirateID == id)
                .Select(y => new PirateImageViewModel
                {
                    PirateID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new PirateCreateViewModel();

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

            vm.Item = (Models.Pirates.SecondaryWeapon)pirate.Item;

            vm.Image.AddRange(images);

            return View("Update", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(PirateCreateViewModel vm)
        {
            var dto = new PirateDto()
            {
                ID = (Guid)vm.ID,

                Name = vm.Name,

                Health = 200,

                HungerLevel = 0,

                ThirstLevel = 0,

                Level = 0,

                XP = 0,

                StatusEffect = (Core.Dto.StatusEffect)vm.StatusEffect,

                PrimaryWeapon = (Core.Dto.PrimaryWeapon)vm.PrimaryWeapon,

                SecondaryWeapon = (Core.Dto.SecondaryWeapon)vm.SecondaryWeapon,

                Item = vm.(Core.Dto.Item)vm.Item,

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
            var result = await _piratesServices.Update(dto);

            if (result == null) { return RedirectToAction("Index"); }
            return RedirectToAction("Index", vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null) { return NotFound(); }

            var pirate = await _piratesServices.DetailsAsync(id);

            if (pirate == null) {  NotFound(); }

            var images = await _context.FilesToDatabase
                                       .Where(x => x.PirateID == id)
                                       .Select(y => new PirateImageViewModel
                                       {
                                           PirateID = y.ID,

                                           ImageID = y.ID,

                                           ImageData = y.ImageData,

                                           ImageTitle = y.ImageTitle,
                                           //😢😢😢😢😢😢😢😢😢😢😢😢😢😢
                                           Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                                       }).ToArrayAsync();

            var vm = new PirateDeleteViewModel();

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

            vm.Item = (Models.Pirates.Item)pirate.Item;

            vm.Image.AddRange(images);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var pirateToDelete = await _piratesServices.Delete(id);

            if (pirateToDelete == null) { return RedirectToAction("Index"); }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveImage(Guid id)
        {
            var dto = new FileToDatabaseDto()
            {
                ID = id
            };

            var image = await _fileServices.RemoveImageFromDatabase(dto);
            if (image == null) { return RedirectToAction("Index"); }
            return RedirectToAction("Index");
        }

        
        [HttpPost, ActionName("CreatePirateOwnership")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRandomPirateOwnership(PirateOwnershipFromStoryViewModel vm)
        {
            int rng = new Random().Next(1, _context.Pirates.Count());

            var sourcePirate = _context.Pirates.OrderByDescending(x => x.Name).Take(rng);

            var dto = new PirateOwnershipDto()
            {
                Name = vm.AddedPirate.Name,

                Health = 200,

                HungerLevel = 0,

                ThirstLevel = 0,

                Level = 0,

                XP = 0,

                StatusEffect = (Core.Dto.StatusEffect)vm.AddedPirate.StatusEffect,

                PrimaryWeapon = (Core.Dto.PrimaryWeapon)vm.AddedPirate.PrimaryWeapon,

                SecondaryWeapon = (Core.Dto.SecondaryWeapon)vm.AddedPirate.SecondaryWeapon,

                Item = (Core.Dto.Item)vm.AddedPirate.Item,

                Files = vm.AddedPirate.Files,

                //Image = vm.AddedPirate.Image.Select(x => new FileToDatabaseDto
                //{
                //    ID = x.ImageID,
                //    ImageData = x.ImageData,
                //    ImageTitle = x.ImageTitle,
                //    PirateID = x.PirateID,
                //}
                //).ToArray()
            };
            //var result = await _storiesServices.Create(dto);


            string result = null; //for now
            if (result != null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", vm);
        }
    }
}
