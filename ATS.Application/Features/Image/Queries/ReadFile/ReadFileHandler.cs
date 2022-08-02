using MediatR;
using Microsoft.Extensions.Configuration;

namespace ATS.Application.Features.Image.Queries.ReadFile
{
    public class ReadFileHandler : IRequestHandler<ReadFileQuery, byte[]>
    {
        private readonly IConfiguration _configuration;

        public ReadFileHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<byte[]> Handle(ReadFileQuery request, CancellationToken cancellationToken)
        {
            string uploadFolder = Path.Combine(_configuration.GetValue<string>("fileConfig:folderPath"), request.getFile.Folder, request.getFile.FileName);
            if (String.IsNullOrEmpty(uploadFolder)) return null;

            try
            {
                var bytes = await File.ReadAllBytesAsync(uploadFolder, cancellationToken);
                return bytes;
            }
            catch
            {
                return null;
            }


        }
    }
}
