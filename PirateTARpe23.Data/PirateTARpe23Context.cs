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
    public class PirateTARpe23Context : DbContext
    {
        public PirateTARpe23Context(DbContextOptions<PirateTARpe23Context> options) : base(options) { }
        public DbSet<Pirate> Pirates { get; set; }
    }
}
