using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantWorkExperience.Commands.DeleteWorkExperience
{
    public record DeleteWorkExperienceCommand(int id) : IRequest<bool>;
}
