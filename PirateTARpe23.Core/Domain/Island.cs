using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PirateTARpe23.Core.Domain
{
    public enum IslandSize
    {
        Small, Medium, Large
    }
    public enum IslandStatus
    {
        FullOfLoot, Plundered
    }
    public class Island
    {
        public Guid IslandID { get; set; }

        public string IslandName { get; set; }

        public IslandSize IslandSize { get; set; }

        public IslandStatus IslandStatus { get; set; }

        public int LevelRequirement { get; set; }

        public int XPReward { get; set; }
    }
}
