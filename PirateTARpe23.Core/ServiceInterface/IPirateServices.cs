using PirateTARpe23.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PirateTARpe23.Core.ServiceInterface
{
    public interface IPirateServices
    {
        Task<Pirate> DetailsAsync(Guid id);
    }
}
