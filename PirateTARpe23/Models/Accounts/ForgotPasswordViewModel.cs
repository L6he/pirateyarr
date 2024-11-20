﻿using System.ComponentModel.DataAnnotations;

namespace PirateTARpe23.Models.Accounts
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
