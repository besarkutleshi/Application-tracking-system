using ATS.Application.Contracts.Persistence.Applicant;
using ATS.Application.DTO_s.Applicant.Education;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantEducation.Commands.CreateEducation
{
    public class CreateEducationHandler : IRequestHandler<CreateEducationCommand, CreateEducationDTO>
    {
        private readonly IApplicantEducation _applicantEducation;
        private readonly IMapper _mapper;

        public CreateEducationHandler(IApplicantEducation applicantEducation, IMapper mapper)
        {
            _applicantEducation = applicantEducation;
            _mapper = mapper;
        }

        public async Task<CreateEducationDTO> Handle(CreateEducationCommand request, CancellationToken cancellationToken)
        {
            var education = _mapper.Map<ATS.Domain.Models.ApplicantEducation>(request.createEducation);
            var created = await _applicantEducation.AddAsync(education, cancellationToken);
            return _mapper.Map<CreateEducationDTO>(created);
        }
    }
}
