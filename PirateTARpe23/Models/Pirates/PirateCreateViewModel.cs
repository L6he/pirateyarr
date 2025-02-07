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
    public enum Item
    {
        ShipsBiscuit, TheLiquid
    }
    //don't worry bout it sweetheart


    public class PirateCreateViewModel
    {
        public Guid? ID { get; set; }
        public string? Name { get; set; }
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

        public List<IFormFile> Files { get; set; }
        public List<PirateImageViewModel> Image { get; set; } = new List<PirateImageViewModel>();
    }
}
