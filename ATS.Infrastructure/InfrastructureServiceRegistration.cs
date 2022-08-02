using ATS.Application.Contracts.Persistence;
using ATS.Application.Contracts.Persistence.Administration;
using ATS.Application.Contracts.Persistence.Applicant;
using ATS.Application.Contracts.Persistence.Applications;
using ATS.Application.Contracts.Persistence.JobVacancy;
using ATS.Infrastructure.Persistence;
using ATS.Infrastructure.Repositories.Administration;
using ATS.Infrastructure.Repositories.Applicant;
using ATS.Infrastructure.Repositories.Applications;
using ATS.Infrastructure.Repositories.JobVacancy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ATS.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<JobApplication_HRContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("JobApplicationConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            services.AddScoped<IApplicantProfile, ApplicantProfileRepository>();
            services.AddScoped<IApplicantEducation, ApplicantEducationRepository>();
            services.AddScoped<IApplicantExperience, ApplicantExperienceRepository>();
            services.AddScoped<IApplicantSkill, ApplicantSkillsRepository>();
            services.AddScoped<IApplicantLanguage, ApplicantLanguagesRepository>();


            services.AddScoped<IOpenJob, OpenJobRepository>();
            services.AddScoped<IJobRequirement, JobRequirementRepository>();
            services.AddScoped<IJobResponsibility, JobResponsibilityRepository>();
            services.AddScoped<IJobCategory, JobCategoryRepository>();

            services.AddScoped<IRole, RoleRepostiory>();
            services.AddScoped<IUser, UserRepository>();
            services.AddScoped<IAuthentication, AuthenticationRepository>();

            services.AddScoped<INote, NotesRepository>();
            services.AddScoped<IQuestion, QuestionRepository>();
            services.AddScoped<IInterview, InterviewRepository>();
            services.AddScoped<IApplication, ApplicationRepository>();

            services.AddScoped<DbConnection>();

            return services;
        }
    }
}
