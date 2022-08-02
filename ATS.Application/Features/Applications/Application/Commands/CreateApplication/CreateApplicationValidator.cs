using ATS.Application.DTO_s.Administration.Applications.Application;
using ATS.Application.Features.Applications.Question.Commands.AddApplicationQuestions;
using FluentValidation;

namespace ATS.Application.Features.Applications.Application.Commands.CreateApplication
{
    public class CreateApplicationValidator : AbstractValidator<CreateApplicationDTO>
    {
        public CreateApplicationValidator()
        {
            RuleFor(a => a.UserId).GreaterThan(0);
            RuleFor(a => a.AplicantProfileId).GreaterThan(0);
            RuleFor(a => a.ApplicationTypeId).GreaterThan(0);
            RuleFor(a => a.OpenJobId).GreaterThan(0);
            RuleFor(a => a.Status).NotEmpty();
            RuleFor(a => a.InsertBy).GreaterThan(0);
            RuleFor(a => a.ApplicationDate).NotEmpty();
            RuleFor(a => a.AplicantQuestions.Count).GreaterThan(0);
            RuleForEach(a => a.AplicantQuestions).SetValidator(new CreateApplicationQuestionsValidator());
        }
    }
}
