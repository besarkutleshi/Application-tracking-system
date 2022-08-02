using ATS.Application.Contracts.Persistence.JobVacancy;
using ATS.Application.DTO_s.OpenJob.JobCategory;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobCategory.Commads.CreateJobCategory
{
    public class CreateJobCategoryHandler : IRequestHandler<CreateJobCategoryCommand, CreateJobCategoryDTO>
    {
        private readonly IMapper _mapper;
        private readonly IJobCategory _jobCategory;

        public CreateJobCategoryHandler(IMapper mapper, IJobCategory jobCategory)
        {
            _mapper = mapper;
            _jobCategory = jobCategory;
        }

        public async Task<CreateJobCategoryDTO> Handle(CreateJobCategoryCommand request, CancellationToken cancellationToken)
        {
            var jobCategory = _mapper.Map<ATS.Domain.Models.JobCategory>(request.createJobCategory);
            var category = await _jobCategory.AddAsync(jobCategory, cancellationToken);
            return _mapper.Map<CreateJobCategoryDTO>(category);
        }
    }
}
