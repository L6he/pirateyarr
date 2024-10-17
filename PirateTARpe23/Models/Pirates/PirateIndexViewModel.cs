using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PirateTARpe23.Models.Pirates
{
    public enum StatusEffect
    {
        Clear,
        Bleeding,
        Poisoned,
        HasScurvy,
    }
    public enum PrimaryWeapon
    {
        Blunderbuss, Musket, Cannon, FlintlockPistol
    }
    public enum SecondaryWeapon
    {
        Dagger, Scimitar, Cutlass
    }
    public class PirateIndexViewModel
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public double Health { get; set; }
        public StatusEffect StatusEffect { get; set; }
        public double XP { get; set; }
        public int Level { get; set; }
        public PrimaryWeapon PrimaryWeapon { get; set; }
        public SecondaryWeapon SecondaryWeapon { get; set; }
        public string? Item { get; set; }
        public double HungerLevel { get; set; }
        public double ThirstLevel { get; set; }
    }
}
