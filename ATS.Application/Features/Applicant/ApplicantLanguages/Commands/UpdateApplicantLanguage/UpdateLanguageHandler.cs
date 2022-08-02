using ATS.Application.Contracts.Persistence.Applicant;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantLanguages.Commands.UpdateApplicantLanguage
{
    public class UpdateLanguageHandler : IRequestHandler<UpdateLanguageCommand, bool>
    {
        private readonly IApplicantLanguage _applicantLanguage;
        private readonly IMapper _mapper;

        public UpdateLanguageHandler(IApplicantLanguage applicantLanguage, IMapper mapper)
        {
            _applicantLanguage = applicantLanguage;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
        {
            var update = _mapper.Map<ATS.Domain.Models.ApplicantLanguage>(request.updateLanguage);
            var updated = await _applicantLanguage.UpdateAsync(update, cancellationToken);
            return updated;
        }
    }
}
