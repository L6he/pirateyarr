using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PirateTARpe23.Core.Domain
{
    public enum ProfileStatus
    {
        Active,
        Abandoned,
        Deactivated,
        Locked,
        Banned,
        ManualReviewNecessary
    }
    public class PlayerProfile
    {
        public Guid ID { get; set; }

        public Guid ApplicationUserID { get; set; }

        public string ScreenName { get; set; }

        public int dabloons { get; set; }

        public int epicfortnitevictoryroyales { get; set; }

        public ProfileStatus CurrentStatus { get; set; }

        public bool IsAdmin { get; set; }
    }
}
