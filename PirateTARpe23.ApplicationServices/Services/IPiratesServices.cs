using Microsoft.EntityFrameworkCore;
using PirateTARpe23.Core.Domain;
using PirateTARpe23.Core.ServiceInterface;
using PirateTARpe23.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PirateTARpe23.ApplicationServices.Services
{
    public class IPiratesServices : IPirateServices
    {
        private readonly PirateTARpe23Context _context;
        //private readonly IFileServices _fileServices;

        public IPiratesServices(PirateTARpe23Context context /*, IFileServices fileServices*/)
        {
            _context = context;
            //_fileServices = fileServices
        }

        public async Task<Pirate> DetailsAsync(Guid id)
        {
            var result = await _context.Pirates
                .FirstOrDefaultAsync(x => x.ID == id);
            return result;
        }
    }
}
