using ATS.Application.DTO_s.OpenJob.JobCategory;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobCategory.Commads.CreateJobCategory
{
    public record CreateJobCategoryCommand(CreateJobCategoryDTO createJobCategory) : IRequest<CreateJobCategoryDTO>;
}
