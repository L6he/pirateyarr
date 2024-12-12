using PirateTARpe23.Core.Dto;

namespace PirateTARpe23.Models.Stories
{
    public class PirateOwnershipFromStoryViewModel
    {
        public string PlayerProfileGUID { get; set; }

        public string StoryGUID { get; set; }

        public PirateOwnershipDto AddedPirate { get; set; }
    }
}
