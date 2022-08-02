using ATS.Application.Contracts.Persistence.Applications;
using ATS.Application.DTO_s.Administration.Applications.Question;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.Applications.Question.Queries.GetQuestions
{
    public class GetQuestionsHandler : IRequestHandler<GetQuestionsQuery, List<QuestionDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IQuestion _question;

        public GetQuestionsHandler(IMapper mapper, IQuestion question)
        {
            _mapper = mapper;
            _question = question;
        }

        public async Task<List<QuestionDTO>> Handle(GetQuestionsQuery request, CancellationToken cancellationToken)
        {
            var questions = await _question.GetQuestion(cancellationToken);

            return _mapper.Map<List<QuestionDTO>>(questions);
        }
    }
}
