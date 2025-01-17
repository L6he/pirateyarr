namespace PirateTARpe23.Models.Profiles
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
    public class ProfileRegisterViewModel
    {
        
        
            public Guid ID { get; set; }

            public string ApplicationUserID { get; set; }

            public string ScreenName { get; set; }

            public int dabloons { get; set; }

            public int epicfortnitevictoryroyales { get; set; }

            public ProfileStatus CurrentStatus { get; set; }

            public bool IsAdmin { get; set; }
        }
    }
