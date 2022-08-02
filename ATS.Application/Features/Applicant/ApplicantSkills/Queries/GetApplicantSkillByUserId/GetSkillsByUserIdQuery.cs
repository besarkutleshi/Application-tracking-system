using ATS.Application.DTO_s.Applicant.Skill;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantSkills.Queries.GetApplicantSkillByUserId
{
    public record GetSkillsByUserIdQuery(int userId) : IRequest<List<ListSkillsDTO>>;
}
