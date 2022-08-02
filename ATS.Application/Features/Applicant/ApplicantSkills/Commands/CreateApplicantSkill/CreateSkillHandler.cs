using ATS.Application.Contracts.Persistence.Applicant;
using ATS.Application.DTO_s.Applicant.Skill;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantSkills.Commands.CreateApplicantSkill
{
    public class CreateSkillHandler : IRequestHandler<CreateSkillCommand, CreateSkillDTO>
    {
        private readonly IMapper _mapper;
        private readonly IApplicantSkill _applicantSkill;

        public CreateSkillHandler(IMapper mapper, IApplicantSkill applicantSkill)
        {
            _mapper = mapper;
            _applicantSkill = applicantSkill;
        }

        public async Task<CreateSkillDTO> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = _mapper.Map<ATS.Domain.Models.ApplicantSkill>(request.createSkill);
            var created = await _applicantSkill.AddAsync(skill, cancellationToken);
            return _mapper.Map<CreateSkillDTO>(created);
        }
    }
}
