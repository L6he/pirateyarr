using PirateTARpe23.Core.Domain;

namespace PirateTARpe23.Models.Islands
{
    public enum IslandSize
    {
        Small, Medium, Large
    }
    public class IslandIndexViewModel
    {
        public Guid IslandID { get; set; }

        public string IslandName { get; set; }

        public IslandSize IslandSize { get; set; }

        public IslandStatus IslandStatus { get; set; }

        public int LevelRequirement { get; set; }

        public int XPReward { get; set; }
    }
}
