using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PirateTARpe23.Core.Domain
{
    public class PirateOwnership : Pirate
    {
        public Guid OwnershipID { get; set; }

        public double Health { get; set; }

        public StatusEffect StatusEffect { get; set; }

        public double XP { get; set; }

        public double XPNextLevel { get; set; }

        public int Level { get; set; }

        public PrimaryWeapon PrimaryWeapon { get; set; }

        public SecondaryWeapon SecondaryWeapon { get; set; }

        public Item Item { get; set; }

        public double HungerLevel { get; set; }

        public double ThirstLevel { get; set; }
    }
}
