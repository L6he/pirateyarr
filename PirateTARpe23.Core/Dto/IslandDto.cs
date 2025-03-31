using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PirateTARpe23.Core.Dto
{
    public enum IslandStatus
    {
        FullOfLoot, Plundered
    }
    public class IslandDto
    {
        public Guid IslandID { get; set; }

        public string IslandName { get; set; }

        public bool IsBigIsland { get; set; }

        public IslandStatus IslandStatus { get; set; }

        public int LevelRequirement { get; set; }

        public double XPReward { get; set; }
    }
}
