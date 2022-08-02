using ATS.Application.DTO_s.OpenJob.JobCategory;
using FluentValidation;

namespace ATS.Application.Features.JobVacancy.JobCategory.Commads.UpdateJobCategory
{
    public class UpdateJobCategoryValidator : AbstractValidator<UpdateJobCategoryDTO>
    {
        public UpdateJobCategoryValidator()
        {
            RuleFor(a => a.Id).NotEmpty();
            RuleFor(a => a.Id).GreaterThan(0);
            RuleFor(a => a.UpdateBy).NotEmpty();
            RuleFor(a => a.UpdateBy).GreaterThan(0);
            RuleFor(a => a.Category).NotEmpty();
            RuleFor(a => a.CategoryAlbania).NotEmpty();
            RuleFor(a => a.Departament).NotEmpty();
            RuleFor(a => a.Division).NotEmpty();
        }
    }
}
