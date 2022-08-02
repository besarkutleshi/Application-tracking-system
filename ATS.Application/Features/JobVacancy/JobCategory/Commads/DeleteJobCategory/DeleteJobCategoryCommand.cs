using MediatR;

namespace ATS.Application.Features.JobVacancy.JobCategory.Commads.DeleteJobCategory
{
    public record DeleteJobCategoryCommand(int jobCategoryId) : IRequest<bool>;
}
