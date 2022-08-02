using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantSkills.Commands.DeleteApplicantSkill
{
    public record DeleteSkillCommand(int skillId) : IRequest<bool>;
}
