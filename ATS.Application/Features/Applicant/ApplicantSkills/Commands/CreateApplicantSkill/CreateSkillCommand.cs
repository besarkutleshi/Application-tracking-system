using ATS.Application.DTO_s.Applicant.Skill;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantSkills.Commands.CreateApplicantSkill
{
    public record CreateSkillCommand(CreateSkillDTO createSkill) : IRequest<CreateSkillDTO>;
}
