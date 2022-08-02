using ATS.Application.DTO_s.Applicant.Image;
using MediatR;

namespace ATS.Application.Features.Image.Commands.DeleteImage
{
    public record DeleteImageCommand(DeleteImageDTO deleteImage) : IRequest<bool>;
}
