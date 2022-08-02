using ATS.Application.DTO_s.OpenJob.JobCategory;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobCategory.Commads.UpdateJobCategory
{
    public record UpdateJobCategoryCommand(UpdateJobCategoryDTO updateJobCategory) : IRequest<bool>;
}
