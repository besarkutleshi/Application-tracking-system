using ATS.Application.Contracts.Persistence.Applicant;
using ATS.Application.DTO_s.Applicant.Experiences;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantWorkExperience.Commands.CreateWorkExperience
{
    public class CreateWorkExperienceHandler : IRequestHandler<CreateWorkExperienceCommand, CreateWorkExperienceDTO>
    {
        private readonly IApplicantExperience _applicantExperience;
        private readonly IMapper _mapper;

        public CreateWorkExperienceHandler(IApplicantExperience applicantExperience, IMapper mapper)
        {
            _applicantExperience = applicantExperience;
            _mapper = mapper;
        }

        public async Task<CreateWorkExperienceDTO> Handle(CreateWorkExperienceCommand request, CancellationToken cancellationToken)
        {
            var experience = _mapper.Map<ATS.Domain.Models.ApplicantWorkExperience>(request.createWorkExperience);
            var created = await _applicantExperience.AddAsync(experience, cancellationToken);
            return _mapper.Map<CreateWorkExperienceDTO>(created);
        }
    }
}
