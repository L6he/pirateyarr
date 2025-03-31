using PirateTARpe23.Core.Dto;
using PirateTARpe23.Core.Domain;
using PirateTARpe23.Models.Pirates;

namespace PirateTARpe23.Models.Islands
{
    public class IslandCreateViewModel
    {
        public Guid? IslandID { get; set; }

        public string IslandName { get; set; }

        public bool IsBigIsland { get; set; }

        public IslandStatus IslandStatus { get; set; }

        public int LevelRequirement { get; set; }

        public int XPReward { get; set; }
    }
}