﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PirateTARpe23.Core.Dto
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
    public enum Item
    {
        ShipsBiscuit, TheLiquid
    }
    //don't worry bout it sweetheart
    public class PirateDto
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public double Health { get; set; }
        public StatusEffect StatusEffect { get; set; }
        public double XP { get; set; }
        public int Level { get; set; }
        public PrimaryWeapon PrimaryWeapon { get; set; }
        public SecondaryWeapon SecondaryWeapon { get; set; }
        public Item Item { get; set; }
        public double HungerLevel { get; set; }
        public double ThirstLevel { get; set; }

        
        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToDatabaseDto> Image { get; set; } = new List<FileToDatabaseDto>();
         
        
    }
}
