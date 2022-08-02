using ATS.Application.DTO_s.Administration.Applications.Interview;
using FluentValidation;

namespace ATS.Application.Features.Applications.Interview.Commands.CreateInterview
{
    public class CreateInterviewValidator : AbstractValidator<CreateInterviewDTO>
    {
        public CreateInterviewValidator()
        {
            RuleFor(a => a.InterviewDate).GreaterThan(DateTime.Now);
            RuleFor(a => a.InsertBy).GreaterThan(0);
            RuleFor(a => a.ApplicationId).GreaterThan(0);
            RuleFor(a => a.Description).NotEmpty();
        }
    }
}
