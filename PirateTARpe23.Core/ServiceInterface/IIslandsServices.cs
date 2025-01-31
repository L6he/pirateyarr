using PirateTARpe23.Core.Domain;
using PirateTARpe23.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PirateTARpe23.Core.ServiceInterface
{
    public interface IIslandsServices
    {
        Task<Island> DetailsAsync(Guid id);
        Task<Island> Create(IslandDto dto);
        Task<Island> Update(IslandDto dto);
        Task<Island> Delete(Guid id);
    }
}
