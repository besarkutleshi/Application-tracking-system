using ATS.Application.DTO_s.Applicant.Image;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantProfile.Commands.InsertImage
{
    public record InsertImageCommand(InsertImageDTO InsertImage) : IRequest<bool>;
}
