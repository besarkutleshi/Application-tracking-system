using ATS.Application.DTO_s.Administration.Applications.Question;
using FluentValidation;

namespace ATS.Application.Features.Applications.Question.Commands.AddApplicationQuestions
{
    public class CreateApplicationQuestionsValidator : AbstractValidator<CreateApplicationQuestionDTO>
    {
        public CreateApplicationQuestionsValidator()
        {
            RuleFor(a => a.HasAnswer).InclusiveBetween(0, 1);
            RuleFor(a => a.Answer).NotEmpty().When(a => a.HasAnswer.Equals(1));
        }
    }
}
