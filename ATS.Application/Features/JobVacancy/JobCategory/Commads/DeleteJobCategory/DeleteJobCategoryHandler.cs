using ATS.Application.Contracts.Persistence.JobVacancy;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobCategory.Commads.DeleteJobCategory
{
    public class DeleteJobCategoryHandler : IRequestHandler<DeleteJobCategoryCommand, bool>
    {
        private readonly IJobCategory _jobCategory;

        public DeleteJobCategoryHandler(IJobCategory jobCategory)
        {
            _jobCategory = jobCategory;
        }

        public async Task<bool> Handle(DeleteJobCategoryCommand request, CancellationToken cancellationToken)
        {
            if (request.jobCategoryId < 1) throw new Exception("Category Id must be greater than 0");
            return await _jobCategory.DeleteAsync(request.jobCategoryId, cancellationToken);
        }
    }
}
