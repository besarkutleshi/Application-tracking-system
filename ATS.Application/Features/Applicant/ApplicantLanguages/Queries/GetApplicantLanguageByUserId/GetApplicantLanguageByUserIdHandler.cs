using ATS.Application.Contracts.Persistence.Applicant;
using ATS.Application.DTO_s.Applicant.Languages;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantLanguages.Queries.GetApplicantLanguageByUserId
{
    public class GetApplicantLanguageByUserIdHandler : IRequestHandler<GetApplicantLanguageByUserIdQuery, List<ListLanguagesDTO>>
    {
        private readonly IApplicantLanguage _applicantLanguage;
        private readonly IMapper _mapper;

        public GetApplicantLanguageByUserIdHandler(IApplicantLanguage applicantLanguage, IMapper mapper)
        {
            _applicantLanguage = applicantLanguage;
            _mapper = mapper;
        }

        public async Task<List<ListLanguagesDTO>> Handle(GetApplicantLanguageByUserIdQuery request, CancellationToken cancellationToken)
        {
            if (request.userId < 1) throw new Exception("User Id must be greater than 0");

            var list = await _applicantLanguage.GetApplicantLanguagesByUserId(request.userId, cancellationToken);
            return _mapper.Map<List<ListLanguagesDTO>>(list);
        }
    }
}
