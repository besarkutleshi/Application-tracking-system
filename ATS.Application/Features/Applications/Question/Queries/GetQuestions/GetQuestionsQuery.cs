using ATS.Application.DTO_s.Administration.Applications.Question;
using MediatR;

namespace ATS.Application.Features.Applications.Question.Queries.GetQuestions
{
    public record GetQuestionsQuery : IRequest<List<QuestionDTO>>;
}
