using ATS.Application.Contracts.Persistence.Applications;
using ATS.Application.DTO_s.Administration.Applications.Question;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Applications.Question.Queries.GetApplicationQuestions
{
    public class GetApplicationQuestionsHandler : IRequestHandler<GetApplicationQuestionsQuery, List<ApplicationQuestionDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IQuestion _question;

        public GetApplicationQuestionsHandler(IMapper mapper, IQuestion question)
        {
            _mapper = mapper;
            _question = question;
        }

        public async Task<List<ApplicationQuestionDTO>> Handle(GetApplicationQuestionsQuery request, CancellationToken cancellationToken)
        {
            if (request.applicationId < 1) throw new Exception("Application Id must be greater than 0");

            var questions = await _question.GetApplicationQuestions(request.applicationId, cancellationToken);

            return _mapper.Map<List<ApplicationQuestionDTO>>(questions);
        }
    }
}
