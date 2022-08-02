using ATS.Application.Contracts.Persistence.Applicant;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantEducation.Commands.AddEducationCertificate
{
    public class AddEducationCertificateHandler : IRequestHandler<AddEducationCertificateCommand, bool>
    {
        private readonly IApplicantEducation _applicantEducation;
        private readonly IMapper _mapper;

        public AddEducationCertificateHandler(IApplicantEducation applicantEducation, IMapper mapper)
        {
            _applicantEducation = applicantEducation;
            _mapper = mapper;
        }

        public async Task<bool> Handle(AddEducationCertificateCommand request, CancellationToken cancellationToken)
        {
            var certificate = _mapper.Map<ATS.Domain.Models.ApplicantCertificate>(request.educationCertificate);
            var added = await _applicantEducation.AddEducationCertificate(certificate, cancellationToken);
            return added;
        }
    }
}
