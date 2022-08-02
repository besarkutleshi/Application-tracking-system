using ATS.Application.Contracts.Persistence.Applicant;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantSkills.Commands.DeleteApplicantSkill
{
    public class DeleteSkillHandler : IRequestHandler<DeleteSkillCommand, bool>
    {
        private readonly IApplicantSkill _applicantSkill;

        public DeleteSkillHandler(IApplicantSkill applicantSkill)
        {
            _applicantSkill = applicantSkill;
        }

        public async Task<bool> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
        {
            if (request.skillId < 1) throw new Exception("Skill Id must be greater than 0");

            return await _applicantSkill.DeleteAsync(request.skillId, cancellationToken);
        }
    }
}
