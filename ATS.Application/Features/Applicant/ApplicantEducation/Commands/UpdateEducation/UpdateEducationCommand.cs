using ATS.Application.DTO_s.Applicant.Education;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantEducation.Commands.UpdateEducation
{
    public record UpdateEducationCommand(UpdateEducationDTO updateEducation) : IRequest<bool>;
}
