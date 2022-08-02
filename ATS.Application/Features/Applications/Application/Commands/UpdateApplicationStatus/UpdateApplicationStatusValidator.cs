using ATS.Application.DTO_s.Administration.Applications.Application;
using FluentValidation;

namespace ATS.Application.Features.Applications.Application.Commands.UpdateApplicationStatus
{
    public class UpdateApplicationStatusValidator : AbstractValidator<UpdateApplicationsDTO>
    {
        public UpdateApplicationStatusValidator()
        {
            RuleFor(a => a.Id).GreaterThan(0);
            RuleFor(a => a.Status).NotEmpty();
            RuleFor(a => a.UpdateBy).GreaterThan(0);
        }
    }
}
