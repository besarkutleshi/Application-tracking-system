using ATS.Application.DTO_s.Applicant.Experiences;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantWorkExperience.Commands.CreateWorkExperience
{
    public record CreateWorkExperienceCommand(CreateWorkExperienceDTO createWorkExperience) : IRequest<CreateWorkExperienceDTO>;
}
