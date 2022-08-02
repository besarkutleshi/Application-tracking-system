using ATS.Application.Contracts.Persistence.Applicant;
using MediatR;

namespace ATS.Application.Features.Applicant.ApplicantLanguages.Commands.DeleteApplicantLanguage
{
    public class DeleteLanguageHandler : IRequestHandler<DeleteLangaugeCommand, bool>
    {
        private readonly IApplicantLanguage _applicantLanguage;

        public DeleteLanguageHandler(IApplicantLanguage applicantLanguage)
        {
            _applicantLanguage = applicantLanguage;
        }

        public async Task<bool> Handle(DeleteLangaugeCommand request, CancellationToken cancellationToken)
        {
            if (request.languageId < 1) throw new Exception("Language Id must be greater than 0.");

            return await _applicantLanguage.DeleteAsync(request.languageId, cancellationToken);
        }
    }
}
