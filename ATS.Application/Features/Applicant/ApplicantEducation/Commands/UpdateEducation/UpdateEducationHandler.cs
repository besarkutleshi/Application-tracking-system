using ATS.Application.Contracts.Persistence.Applicant;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantEducation.Commands.UpdateEducation
{
    public class UpdateEducationHandler : IRequestHandler<UpdateEducationCommand, bool>
    {
        private readonly IApplicantEducation _applicantEducation;
        private readonly IMapper _mapper;

        public UpdateEducationHandler(IApplicantEducation applicantEducation, IMapper mapper)
        {
            _applicantEducation = applicantEducation;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateEducationCommand request, CancellationToken cancellationToken)
        {
            var education = _mapper.Map<ATS.Domain.Models.ApplicantEducation>(request.updateEducation);
            var updated = await _applicantEducation.UpdateAsync(education, cancellationToken);
            return updated;
        }
    }
}
