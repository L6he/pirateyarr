﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PirateTARpe23.Core.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }

        public Guid PlayerProfileID { get; set; } //nigga!!!!

        public bool IsAdmin { get; set; }
    }
}
