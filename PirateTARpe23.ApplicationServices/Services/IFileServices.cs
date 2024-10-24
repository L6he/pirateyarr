using Microsoft.Extensions.Hosting;
using PirateTARpe23.Core.Domain;
using PirateTARpe23.Core.Dto;
using PirateTARpe23.Core.ServiceInterface;
using PirateTARpe23.Data;

namespace PirateTARpe23.ApplicationServices.Services
{
    public class IFileServices : Core.ServiceInterface.IFileServices
    {
        private readonly IHostEnvironment _webHost;
        private readonly PirateTARpe23Context _context;

        public IFileServices
            (IHostEnvironment webHost,
             PirateTARpe23Context context)
        {
            _webHost = webHost;
            _context = context;
        }

        public void UploadFilesToDb(PirateDto dto, Pirate domain)
        {
            if (dto.Files != null && dto.Files.Count > 0) 
            {
                foreach (var image in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase files = new()
                        {
                            ID = Guid.NewGuid(),
                            ImageTitle = image.FileName,
                            PirateID = domain.ID
                        };
                        image.CopyTo(target);
                        files.ImageData = target.ToArray();
                        _context.FilesToDatabase.Add(files);
                    }
                }
            }
        }
    }
}
