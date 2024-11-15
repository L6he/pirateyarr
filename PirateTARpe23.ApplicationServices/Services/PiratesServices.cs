using Microsoft.EntityFrameworkCore;
using PirateTARpe23.Core.Domain;
using PirateTARpe23.Core.Dto;
using PirateTARpe23.Core.ServiceInterface;
using PirateTARpe23.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PirateTARpe23.ApplicationServices.Services
{
    public class PiratesServices : IPiratesServices
    {
        private readonly PirateTARpe23Context _context;
        private readonly IFileServices _fileServices;

        public PiratesServices(PirateTARpe23Context context , IFileServices fileServices)
        {
            _context = context;
            _fileServices = fileServices;
        }

        public async Task<Pirate> DetailsAsync(Guid id)
        {
            var result = await _context.Pirates
                .FirstOrDefaultAsync(x => x.ID == id);
            return result;
        }

        public async Task<Pirate> Create(PirateDto dto)
        {
            Pirate pirate = new();
            //set by saavis
            pirate.Name = dto.Name;
            pirate.ID = Guid.NewGuid();
            pirate.Health = 200;
            pirate.XP = 0;
            pirate.Level = 0;
            pirate.HungerLevel = 0;
            pirate.ThirstLevel = 0;
            pirate.StatusEffect = Core.Domain.StatusEffect.Clear;
            

            //set by yuusa
            pirate.PrimaryWeapon = (Core.Domain.PrimaryWeapon)dto.PrimaryWeapon;
            pirate.SecondaryWeapon = (Core.Domain.SecondaryWeapon)dto.SecondaryWeapon;
            pirate.Item = dto.Item;

            //fairusu
            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDb(dto, pirate);
            }

            await _context.Pirates.AddAsync(pirate);
            await _context.SaveChangesAsync();

            return pirate;
        }

        public async Task<Pirate> Update(PirateDto dto)
        {
            Pirate pirate = new();
            //set by saavis
            pirate.Name = dto.Name;
            pirate.ID = Guid.NewGuid();
            pirate.Health = 200;
            pirate.XP = 0;
            pirate.Level = 0;
            pirate.HungerLevel = 0;
            pirate.ThirstLevel = 0;
            pirate.StatusEffect = Core.Domain.StatusEffect.Clear;

            //set by yuusa
            pirate.PrimaryWeapon = (Core.Domain.PrimaryWeapon)dto.PrimaryWeapon;
            pirate.SecondaryWeapon = (Core.Domain.SecondaryWeapon)dto.SecondaryWeapon;
            pirate.Item = dto.Item;

            //fairusu
            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDb(dto, pirate);
            }
            _context.Pirates.Update(pirate);
            await _context.SaveChangesAsync();

            return pirate;
        }

        public async Task<Pirate> Delete(Guid id)
        {
            var result = await _context.Pirates
                .FirstOrDefaultAsync(x => x.ID == id);
            _context.Pirates.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }
    }
}
