using ATS.Application.Contracts.Persistence.Applicant;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantWorkExperience.Commands.UpdateWorkExperience
{
    public class UpdateWorkExperienceHandler : IRequestHandler<UpdateWorkExperienceCommand, bool>
    {
        private readonly IApplicantExperience _applicantExperience;
        private readonly IMapper _mapper;

        public UpdateWorkExperienceHandler(IApplicantExperience applicantExperience, IMapper mapper)
        {
            _applicantExperience = applicantExperience;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateWorkExperienceCommand request, CancellationToken cancellationToken)
        {
            var experience = _mapper.Map<ATS.Domain.Models.ApplicantWorkExperience>(request.updateWorkExperience);
            var updated = await _applicantExperience.UpdateAsync(experience, cancellationToken);
            return updated;
        }
    }
}
