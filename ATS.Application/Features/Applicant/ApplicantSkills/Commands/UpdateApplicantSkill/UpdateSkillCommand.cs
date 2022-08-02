using ATS.Application.DTO_s.Applicant.Skill;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantSkills.Commands.UpdateApplicantSkill
{
    public record UpdateSkillCommand(UpdateSkillDTO updateSkill) : IRequest<bool>;
}
