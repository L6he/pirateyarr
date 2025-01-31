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
using IslandSize = PirateTARpe23.Core.Domain.IslandSize;

namespace PirateTARpe23.ApplicationServices.Services
{
    public class IslandsServices : IIslandsServices
    {
        private readonly PirateTARpe23Context _context;
        private readonly IFileServices _fileServices;

        public IslandsServices(PirateTARpe23Context context, IFileServices fileServices)
        {
            _context = context;
            _fileServices = fileServices;
        }

        public async Task<Island> DetailsAsync(Guid id)
        {
            var result = await _context.Islands
                .FirstOrDefaultAsync(x => x.IslandID == id);
            return result;
        }

        public async Task<Island> Create(IslandDto dto)
        {
            Random rand = new();
            int size = rand.Next(0, 3);
            Island island = new();
            Island islandSize = size.ToEnum(typeof(IslandSize));

            //fairusu
            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDb(dto, island);
            }

            await _context.Islands.AddAsync(island);
            await _context.SaveChangesAsync();

            return island;
        }

        public async Task<Island> Update(IslandDto dto)
        {
            Random rand = new();
            int size = rand.Next(0, 3);
            Island island = new();
            //Island islandSize = size.ToEnum(typeof(IslandSize));

            //fairusu
            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDb(dto, island);
            }
            //_context.Pirates.Update(island);
            await _context.SaveChangesAsync();

            return island;
        }

        public async Task<Island> Delete(Guid id)
        {
            var result = await _context.Islands
                .FirstOrDefaultAsync(x => x.IslandID == id);
            _context.Islands.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }
    }
}
