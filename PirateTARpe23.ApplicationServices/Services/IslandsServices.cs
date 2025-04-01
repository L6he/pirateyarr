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
    public class IslandsServices : IIslandsServices
    {
        private readonly PirateTARpe23Context _context;

        public IslandsServices(PirateTARpe23Context context)
        {
            _context = context;
        }

        public async Task<Island> DetailsAsync(Guid id)
        {
            var result = await _context.Islands
                .FirstOrDefaultAsync(x => x.IslandID == id);
            return result;
        }

        public async Task<Island> Create(IslandDto dto)
        {
            Island island = new();
            Random rand = new();
            int size = rand.Next(2);
            bool bigness = Convert.ToBoolean(size);
            island.IslandID = Guid.NewGuid();
            island.IslandName = dto.IslandName;
            island.IsBigIsland = bigness;
            island.IslandStatus = Core.Domain.IslandStatus.Unplundered;
            switch (bigness)
            {
                case false: island.XPReward = 500; island.LevelRequirement = 5; break;
                case true: island.XPReward = 1000; island.LevelRequirement = 10; break;
            }

            await _context.Islands.AddAsync(island);
            await _context.SaveChangesAsync();

            return island;
        }

        public async Task<Island> Update(IslandDto dto)
        {
            Island island = new();

            island.IslandID = dto.IslandID;
            island.IslandName = dto.IslandName;
            island.IsBigIsland = dto.IsBigIsland;
            island.IslandStatus = (Core.Domain.IslandStatus)dto.IslandStatus;
            island.LevelRequirement = dto.LevelRequirement;
            island.XPReward = dto.XPReward;

            _context.Islands.Update(island);
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
