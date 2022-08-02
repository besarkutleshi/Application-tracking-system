using ATS.Application.Contracts.Persistence.JobVacancy;
using ATS.Application.DTO_s.OpenJob.JobCategory;
using AutoMapper;
using MediatR;

namespace ATS.Application.Features.JobVacancy.JobCategory.Queries.GetJobCategories
{
    public class GetJobCategoriesHandler : IRequestHandler<GetJobCategoriesQuery, List<ListJobCategoryDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IJobCategory _jobCategory;

        public GetJobCategoriesHandler(IMapper mapper, IJobCategory jobCategory)
        {
            _mapper = mapper;
            _jobCategory = jobCategory;
        }

        public async Task<List<ListJobCategoryDTO>> Handle(GetJobCategoriesQuery request, CancellationToken cancellationToken)
            => _mapper.Map<List<ListJobCategoryDTO>>(await _jobCategory.GetListAsync(cancellationToken));
    }
}
