using ATS.Application.Contracts.Persistence.JobVacancy;
using ATS.Domain.Models;
using ATS.Infrastructure.Persistence;

namespace ATS.Infrastructure.Repositories.JobVacancy
{
    public class JobCategoryRepository : RepositoryBase<JobCategory>, IJobCategory
    {
        public JobCategoryRepository(JobApplication_HRContext jobApplication_HR)
            : base(jobApplication_HR, "JobCategories")
        {

        }
    }
}
