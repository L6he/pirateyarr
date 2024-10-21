namespace PirateTARpe23.Models.Pirates
{
    public class PirateImageViewModel
    {
        public Guid ImageID { get; set; }

        public string ImageTitle { get; set; }

        public byte[] ImageData { get; set; }

        public string Image { get; set; }

        public Guid? PirateID { get; set; }
    }
}
