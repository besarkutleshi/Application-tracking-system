using MediatR;
using Microsoft.Extensions.Configuration;

namespace ATS.Application.Features.Image.Commands.DeleteImage
{
    public class DeleteImageHandler : IRequestHandler<DeleteImageCommand, bool>
	{
		private readonly IConfiguration _configuration;

		public DeleteImageHandler(IConfiguration configuration)
		{
			_configuration = configuration;
		}


		public Task<bool> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
        {
            try
			{
				var deleteImageDTO = request.deleteImage;
				if (deleteImageDTO.FileName != "" && deleteImageDTO.FileName != null)
				{
					string uploadFolder = Path.Combine(_configuration.GetValue<string>("fileConfig:folderPath"), deleteImageDTO.Folder, deleteImageDTO.FileName);
					FileInfo fi = new(uploadFolder);
					if (fi != null)
					{
						File.Delete(uploadFolder);
						fi.Delete();
						return Task.FromResult(true);
					}
					return Task.FromResult(false);
				}
				return Task.FromResult(false);
			}
            catch
			{
				return Task.FromResult(false);
			}
		}
    }
}
