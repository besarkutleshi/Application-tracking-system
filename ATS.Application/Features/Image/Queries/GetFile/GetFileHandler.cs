using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;

namespace ATS.Application.Features.Image.Queries.GetFile
{
    public class GetFileHandler : IRequestHandler<GetFileQuery, FileContentResult>
	{
		private readonly IConfiguration _configuration;

		public GetFileHandler(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		private string GetMimeType(string fileName)
		{
			var provider = new FileExtensionContentTypeProvider();
			string contentType;
			if (!provider.TryGetContentType(fileName, out contentType))
			{
				contentType = "application/octet-stream";
			}
			return contentType;
		}

		public Task<FileContentResult> Handle(GetFileQuery request, CancellationToken cancellationToken)
        {
            try
			{
				string uploadFolder = Path.Combine(_configuration.GetValue<string>("fileConfig:folderPath"), request.getFile.Folder, request.getFile.FileName);

				var mimeType = this.GetMimeType(request.getFile.FileName);

				byte[] fileBytes = null;

				if (File.Exists(uploadFolder))
				{
					fileBytes = File.ReadAllBytes(uploadFolder);
				}
				else
				{
					// Code to handle if file is not present
				}

				var result = new FileContentResult(fileBytes, mimeType)
				{
					FileDownloadName = request.getFile.FileName
				};

				return Task.FromResult(result);
			}
            catch
            {
				return null;
            }
		}
    }
}
