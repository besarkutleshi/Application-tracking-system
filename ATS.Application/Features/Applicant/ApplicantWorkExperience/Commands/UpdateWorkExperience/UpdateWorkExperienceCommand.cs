using ATS.Application.DTO_s.Applicant.Experiences;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantWorkExperience.Commands.UpdateWorkExperience
{
    public record UpdateWorkExperienceCommand(UpdateWorkExperienceDTO updateWorkExperience) : IRequest<bool>;
}
