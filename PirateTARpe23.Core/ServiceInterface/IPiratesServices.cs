using PirateTARpe23.Core.Domain;
using PirateTARpe23.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PirateTARpe23.Core.ServiceInterface
{
    public interface IPiratesServices
    {
        Task<Pirate> DetailsAsync(Guid id);

        Task<Pirate> Create(PirateDto dto);

        Task<Pirate> Update(PirateDto dto);

        Task<Pirate> Delete(Guid id);
    }
}
