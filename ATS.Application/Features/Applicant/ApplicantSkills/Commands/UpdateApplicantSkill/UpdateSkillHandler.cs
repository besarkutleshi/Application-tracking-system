using ATS.Application.Contracts.Persistence.Applicant;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantSkills.Commands.UpdateApplicantSkill
{
    public class UpdateSkillHandler : IRequestHandler<UpdateSkillCommand, bool>
    {
        private readonly IApplicantSkill _applicantSkill;
        private readonly IMapper _mapper;

        public UpdateSkillHandler(IApplicantSkill applicantSkill, IMapper mapper)
        {
            _applicantSkill = applicantSkill;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = _mapper.Map<ATS.Domain.Models.ApplicantSkill>(request.updateSkill);
            return await _applicantSkill.UpdateAsync(skill, cancellationToken);
        }
    }
}
