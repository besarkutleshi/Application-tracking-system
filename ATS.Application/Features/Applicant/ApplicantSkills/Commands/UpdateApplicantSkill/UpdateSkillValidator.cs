using ATS.Application.DTO_s.Applicant.Skill;
using FluentValidation;

namespace ATS.Application.Features.Applicant.ApplicantSkills.Commands.UpdateApplicantSkill
{
    public class UpdateSkillValidator : AbstractValidator<UpdateSkillDTO>
    {
        public UpdateSkillValidator()
        {
            RuleFor(a => a.Id).NotEmpty();
            RuleFor(a => a.Id).GreaterThan(0);
            RuleFor(a => a.UserId).NotEmpty();
            RuleFor(a => a.UserId).GreaterThan(0);
            RuleFor(a => a.AplicantProfileId).NotEmpty();
            RuleFor(a => a.AplicantProfileId).GreaterThan(0);
            RuleFor(a => a.UpdateBy).NotEmpty();
            RuleFor(a => a.UpdateBy).GreaterThan(0);
            RuleFor(a => a.Skill).NotEmpty();
            RuleFor(a => a.KnowledgeLevel).NotEmpty();
        }
    }
}
