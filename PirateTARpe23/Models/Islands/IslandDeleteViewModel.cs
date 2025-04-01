using System.ComponentModel;

namespace PirateTARpe23.Models.Islands
{
    public class IslandDeleteViewModel
    {
        public Guid? IslandID { get; set; }

        public string IslandName { get; set; }

        [DisplayName("Big island?")]
        public bool IsBigIsland { get; set; }

        public IslandStatus IslandStatus { get; set; }

        public int LevelRequirement { get; set; }

        public int XPReward { get; set; }
    }
}
