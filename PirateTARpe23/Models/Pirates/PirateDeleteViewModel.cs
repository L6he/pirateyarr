namespace PirateTARpe23.Models.Pirates
{
    public class PirateDeleteViewModel
    {
        public Guid? ID { get; set; }
        public string Name { get; set; }
        public double Health { get; set; }
        public StatusEffect StatusEffect { get; set; }
        public double XP { get; set; } //haha TitanXP that's like a gpu
        public int Level { get; set; }
        public PrimaryWeapon PrimaryWeapon { get; set; }
        public SecondaryWeapon SecondaryWeapon { get; set; }
         public string? Item { get; set; }
        public double HungerLevel { get; set; }
        public double ThirstLevel { get; set; }
        //public List<IFormFile> Files { get; set; }
        public List<PirateImageViewModel> Image { get; set; } = new List<PirateImageViewModel>();
    }
}

