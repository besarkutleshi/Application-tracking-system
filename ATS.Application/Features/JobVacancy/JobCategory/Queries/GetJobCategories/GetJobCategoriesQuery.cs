using ATS.Application.DTO_s.OpenJob.JobCategory;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobCategory.Queries.GetJobCategories
{
    public record GetJobCategoriesQuery : IRequest<List<ListJobCategoryDTO>>;
}
