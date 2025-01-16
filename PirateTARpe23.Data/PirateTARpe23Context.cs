using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PirateTARpe23.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PirateTARpe23.Data
{
    public class PirateTARpe23Context : IdentityDbContext<ApplicationUser>
    {
        public PirateTARpe23Context(DbContextOptions<PirateTARpe23Context> options) : base(options) { }
        public DbSet<Pirate> Pirates { get; set; }

        public DbSet<FileToDatabase> FilesToDatabase { get; set; }

        public DbSet<IdentityRole> IdentityRoles { get; set; }

        public DbSet<PlayerProfile> PlayerProfiles { get; set; }
    }
}
