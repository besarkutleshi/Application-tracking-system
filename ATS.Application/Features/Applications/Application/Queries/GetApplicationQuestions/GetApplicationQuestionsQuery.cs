using ATS.Application.DTO_s.Administration.Applications.Question;
using MediatR;

namespace ATS.Application.Features.Applications.Application.Queries.GetApplicationQuestions
{
    public record GetApplicationQuestionsQuery(int applicationId) : IRequest<List<ApplicationQuestionDTO>>;
}
