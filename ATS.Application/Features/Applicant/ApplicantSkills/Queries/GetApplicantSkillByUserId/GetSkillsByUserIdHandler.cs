using ATS.Application.Contracts.Persistence.Applicant;
using ATS.Application.DTO_s.Applicant.Skill;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantSkills.Queries.GetApplicantSkillByUserId
{
    public class GetSkillsByUserIdHandler : IRequestHandler<GetSkillsByUserIdQuery, List<ListSkillsDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicantSkill _applicantSkill;

        public GetSkillsByUserIdHandler(IMapper mapper, IApplicantSkill applicantSkill)
        {
            _mapper = mapper;
            _applicantSkill = applicantSkill;
        }

        public async Task<List<ListSkillsDTO>> Handle(GetSkillsByUserIdQuery request, CancellationToken cancellationToken)
        {
            if (request.userId < 1) throw new Exception("User ID must be greater than 0");

            var list = await _applicantSkill.GetApplicantSkillsByUserId(request.userId, cancellationToken);
            return _mapper.Map<List<ListSkillsDTO>>(list);
        }
    }
}
