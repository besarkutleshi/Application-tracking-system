using ATS.Application.DTO_s.Applicant.Image;
using MediatR;

namespace ATS.Application.Features.Image.Commands.UploadImage
{
    public record UploadImageCommand(UploadImageDTO uploadImage) : IRequest<string>;
}
