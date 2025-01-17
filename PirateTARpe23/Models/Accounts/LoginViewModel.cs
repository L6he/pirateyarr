using System.ComponentModel.DataAnnotations;

namespace PirateTARpe23.Models.Accounts
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }

        public string? ReturnURL { get; set; }

        public bool IsAdmin { get; set; }
    }
}
