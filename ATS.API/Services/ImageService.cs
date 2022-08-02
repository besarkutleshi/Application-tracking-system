using ATS.Application.DTO_s.Applicant.Image;
using ATS.Application.Features.Image.Commands.DeleteImage;
using ATS.Application.Features.Image.Commands.UploadImage;
using MediatR;

namespace ATS.API.Services
{
    public class ImageService
    {
        public static async Task<bool> DeleteImage(IMediator _mediatR, string fileName, string folder, CancellationToken token)
        {
            var deleteImageCommand = new DeleteImageCommand(new DeleteImageDTO { FileName = fileName, Folder = folder });
            return await _mediatR.Send(deleteImageCommand, token);
        }

        public static async Task<string> AddImage(IMediator _mediatR, UploadImageDTO uploadImage, CancellationToken token)
        {
            var uploadCommand = new UploadImageCommand(uploadImage);
            return await _mediatR.Send(uploadCommand, token);
        }
    }
}
