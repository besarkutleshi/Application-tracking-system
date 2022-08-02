using ATS.Application.DTO_s.Applicant.Education;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantEducation.Commands.CreateEducation
{
    public record CreateEducationCommand(CreateEducationDTO createEducation) : IRequest<CreateEducationDTO>;
}
