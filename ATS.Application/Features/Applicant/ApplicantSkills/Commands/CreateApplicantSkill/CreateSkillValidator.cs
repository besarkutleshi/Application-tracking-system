using ATS.Application.DTO_s.Applicant.Skill;
using FluentValidation;

namespace ATS.Application.Features.Applicant.ApplicantSkills.Commands.CreateApplicantSkill
{
    public class CreateSkillValidator : AbstractValidator<CreateSkillDTO>
    {
        public CreateSkillValidator()
        {
            RuleFor(a => a.UserId).NotEmpty();
            RuleFor(a => a.UserId).GreaterThan(0);
            RuleFor(a => a.AplicantProfileId).NotEmpty();
            RuleFor(a => a.AplicantProfileId).GreaterThan(0);
            RuleFor(a => a.InsertBy).NotEmpty();
            RuleFor(a => a.InsertBy).GreaterThan(0);
            RuleFor(a => a.Skill).NotEmpty();
            RuleFor(a => a.KnowledgeLevel).NotEmpty();
        }
    }
}
