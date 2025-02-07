using PirateTARpe23.Core.Domain;

namespace PirateTARpe23.Models.Islands
{
    public enum IslandStatus
    {
        FullOfLoot, Plundered
    }
    public class IslandIndexViewModel
    {
        public Guid IslandID { get; set; }

        public string IslandName { get; set; }

        public bool IsBigIsland { get; set; }

        public IslandStatus IslandStatus { get; set; }

        public int LevelRequirement { get; set; }

        public double XPReward { get; set; }
    }
}
