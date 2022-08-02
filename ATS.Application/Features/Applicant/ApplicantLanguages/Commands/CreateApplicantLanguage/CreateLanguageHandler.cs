using ATS.Application.Contracts.Persistence.Applicant;
using ATS.Application.DTO_s.Applicant.Languages;
using AutoMapper;
using MediatR;
namespace ATS.Application.Features.Applicant.ApplicantLanguages.Commands.CreateApplicantLanguage
{
    public class CreateLanguageHandler : IRequestHandler<CreateLanguageCommand, CreateLanguageDTO>
    {
        private readonly IApplicantLanguage _applicantLanguage;
        private readonly IMapper _mapper;

        public CreateLanguageHandler(IApplicantLanguage applicantLanguage, IMapper mapper)
        {
            _applicantLanguage = applicantLanguage;
            _mapper = mapper;
        }

        public async Task<CreateLanguageDTO> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
        {
            var language = _mapper.Map<ATS.Domain.Models.ApplicantLanguage>(request.createLanguage);
            var created = await _applicantLanguage.AddAsync(language, cancellationToken);
            return _mapper.Map<CreateLanguageDTO>(created);
        }
    }
}
