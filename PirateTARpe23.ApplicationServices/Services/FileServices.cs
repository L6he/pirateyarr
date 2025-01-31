using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PirateTARpe23.Core.Domain;
using PirateTARpe23.Core.Dto;
using PirateTARpe23.Core.ServiceInterface;
using PirateTARpe23.Data;

namespace PirateTARpe23.ApplicationServices.Services
{
    public class FileServices : IFileServices
    {
        private readonly IHostEnvironment _webHost;
        private readonly PirateTARpe23Context _context;

        public FileServices
            (
                IHostEnvironment webHost,
                PirateTARpe23Context context
            )
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
        public void UploadFilesToDb(IslandDto dto, Island domain)
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
                            IslandID = domain.IslandID
                        };
                        image.CopyTo(target);
                        files.ImageData = target.ToArray();
                        _context.FilesToDatabase.Add(files);
                    }
                }
            }
        }

        public async Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto)
        {
            var imageID = await _context.FilesToDatabase.FirstOrDefaultAsync(x => x.ID == dto.ID);
            var filePath = _webHost.ContentRootPath + "\\multipleFileUpload\\" + imageID.ImageData;
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            _context.FilesToDatabase.Remove(imageID);
            await _context.SaveChangesAsync();

            return null;
        }
    }
}
