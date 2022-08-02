using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantEducation.Commands.DeleteEducation
{
    public record DeleteEducationCommand(int id) : IRequest<bool>;
}
