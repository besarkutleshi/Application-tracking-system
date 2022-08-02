using MediatR;
using Microsoft.Extensions.Configuration;

namespace ATS.Application.Features.Image.Commands.UploadImage
{
    public class UploadImageHandler : IRequestHandler<UploadImageCommand, string>
	{
		private readonly IConfiguration _configuration;

		public UploadImageHandler(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public Task<string> Handle(UploadImageCommand request, CancellationToken cancellationToken)
        {
            try
			{
				string uniqueFileName = null;
				if (request.uploadImage.File != null)
				{
					// check folderPath for development and production
					string uploadFolder = Path.Combine(_configuration.GetValue<string>("fileConfig:folderPath"), request.uploadImage.Folder);
                    Console.WriteLine(uploadFolder);
					uniqueFileName = request.uploadImage.UserId > 0 ? $"_{request.uploadImage.UserId}_" + request.uploadImage.File.FileName : request.uploadImage.File.FileName;
					string filePath = Path.Combine(uploadFolder, uniqueFileName);
					var file = new FileStream(filePath, FileMode.Create);
					request.uploadImage.File.CopyTo(file);
					file.Close();
					return Task.FromResult(uniqueFileName);

				}
				return null;
			}
            catch
            {
                Console.WriteLine("Error");
				return null;
            }
		}
    }
}
