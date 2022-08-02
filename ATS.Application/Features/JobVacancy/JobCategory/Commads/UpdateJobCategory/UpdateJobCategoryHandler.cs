using ATS.Application.Contracts.Persistence.JobVacancy;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobCategory.Commads.UpdateJobCategory
{
    public class UpdateJobCategoryHandler : IRequestHandler<UpdateJobCategoryCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IJobCategory _jobCategory;

        public UpdateJobCategoryHandler(IMapper mapper, IJobCategory jobCategory)
        {
            _mapper = mapper;
            _jobCategory = jobCategory;
        }

        public async Task<bool> Handle(UpdateJobCategoryCommand request, CancellationToken cancellationToken)
        {
            var jobCategory = _mapper.Map<ATS.Domain.Models.JobCategory>(request.updateJobCategory);
            return await _jobCategory.UpdateAsync(jobCategory, cancellationToken);
        }
    }
}
