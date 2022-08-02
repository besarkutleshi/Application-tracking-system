using ATS.Application.DTO_s.Administration.Applications.Interview;
using FluentValidation;

namespace ATS.Application.Features.Applications.Interview.Commands.UpdateInterview
{
    public class UpdateInterviewValidator : AbstractValidator<UpdateInterviewDTO>
    {
        public UpdateInterviewValidator()
        {
            RuleFor(a => a.InterviewDate).GreaterThan(DateTime.Now);
            RuleFor(a => a.UpdateBy).GreaterThan(0);
            RuleFor(a => a.Description).NotEmpty();
        }
    }
}
