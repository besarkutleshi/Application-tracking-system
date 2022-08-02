using ATS.Application.DTO_s.OpenJob.JobCategory;
using FluentValidation;

namespace ATS.Application.Features.JobVacancy.JobCategory.Commads.CreateJobCategory
{
    public class CreateJobCategoryValidator : AbstractValidator<CreateJobCategoryDTO>
    {
        public CreateJobCategoryValidator()
        {
            RuleFor(a => a.InsertBy).NotEmpty();
            RuleFor(a => a.InsertBy).GreaterThan(0);
            RuleFor(a => a.PhotoFile).NotEmpty();
            RuleFor(a => a.Category).NotEmpty();
            RuleFor(a => a.CategoryAlbania).NotEmpty();
            RuleFor(a => a.Departament).NotEmpty();
            RuleFor(a => a.Division).NotEmpty();
        }
    }
}
