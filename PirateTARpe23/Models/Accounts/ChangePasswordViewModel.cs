using System.ComponentModel.DataAnnotations;

namespace PirateTARpe23.Models.Accounts
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Insert current password: ")]
        public string CurrentPassword { get; set; } 

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Insert new password: ")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Type password again to confirm: ")]
        public string ConfirmPassword { get; set; }
    }
}
