using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PirateTARpe23.Models.Accounts
{
    public class AddPasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Type new password here: ")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Type the password again to confirm: ")]
        [Compare("NewPassword", ErrorMessage = "The new password and its confirmation do not match. Please retry, retard.")]
        public string ConfirmPassword { get; set; }
    }
}
