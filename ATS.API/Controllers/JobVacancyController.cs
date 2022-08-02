using ATS.Application.DTO_s.Applicant.Image;
using ATS.Application.DTO_s.OpenJob.JobRequirements;
using ATS.Application.DTO_s.OpenJob.JobResponsibility;
using ATS.Application.DTO_s.OpenJob.JobVacancy;
using ATS.Application.Features.Image.Queries.ReadFile;
using ATS.Application.Features.JobVacancy.JobRequirement.Commands.CreateJobRequirement;
using ATS.Application.Features.JobVacancy.JobRequirement.Commands.DeleteJobRequirement;
using ATS.Application.Features.JobVacancy.JobRequirement.Commands.UpdateJobRequirement;
using ATS.Application.Features.JobVacancy.JobRequirement.Queries.GetJobRequirementsByJobId;
using ATS.Application.Features.JobVacancy.JobResponsibility.Commands.CreateJobResponsibility;
using ATS.Application.Features.JobVacancy.JobResponsibility.Commands.DeleteJobResponsibility;
using ATS.Application.Features.JobVacancy.JobResponsibility.Commands.UpdateJobResponsibilty;
using ATS.Application.Features.JobVacancy.JobResponsibility.Queries.GetJobResponsibilitesByJobId;
using ATS.Application.Features.JobVacancy.JobVacancy.Commands.CreateJobVacancy;
using ATS.Application.Features.JobVacancy.JobVacancy.Commands.DeleteJobVacancy;
using ATS.Application.Features.JobVacancy.JobVacancy.Commands.UpdateJobVacancy;
using ATS.Application.Features.JobVacancy.JobVacancy.Queries.GetJobVacancies;
using ATS.Application.Features.JobVacancy.JobVacancy.Queries.GetJobVacancyById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ATS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobVacancyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobVacancyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddJobVacancy(CreateJobDTO createJob, CancellationToken cancellationToken)
        {
            var createJobCommand = new CreateJobVacancyCommand(createJob);
            var addedJob = await _mediator.Send(createJobCommand, cancellationToken);
            return addedJob is not null ? Ok(addedJob.Id) : BadRequest("Can not add Job Vacancy");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJobVacancy(UpdateJobDTO updateJob, CancellationToken cancellationToken)
        {
            var updateJobCommand = new UpdateJobVacancyCommand(updateJob);
            var updatedJob = await _mediator.Send(updateJobCommand, cancellationToken);
            return updatedJob ? Ok() : BadRequest("Can not update Job Vacancy");
        }

        [HttpDelete("{jobId}")]
        public async Task<IActionResult> DeleteJobVacancy(int id, CancellationToken cancellationToken)
        {
            var deleteJobCommand = new DeleteJobVacancyCommand(id);
            var deletedJob = await _mediator.Send(deleteJobCommand, cancellationToken);
            return deletedJob ? Ok() : BadRequest("Can not delete Job Vacancy");
        }

        [HttpGet]
        public async Task<IActionResult> GetJobVacancies(CancellationToken cancellationToken)
        {
            var getJobVacanciesQuery = new GetJobVacanciesQuery();
            var jobVacancies = await _mediator.Send(getJobVacanciesQuery, cancellationToken);
            if(jobVacancies.Count() > 0)
            {
                foreach (var item in jobVacancies)
                {
                    var readFileQuery = new ReadFileQuery(new GetFileDTO { FileName = item.Category.Photo, Folder = "CategoriesPhotos" });
                    byte[] bytes = await _mediator.Send(readFileQuery, cancellationToken);
                    item.Category.ImageBytes = bytes;
                }
            }
            return Ok(jobVacancies);
        }

        [HttpGet("{jobId}")]
        public async Task<IActionResult> GetJobVacancy(int jobId, CancellationToken cancellationToken)
        {
            var getJobVacancyQuery = new GetJobVacancyByIdQuery(jobId);
            var jobVacancy = await _mediator.Send(getJobVacancyQuery, cancellationToken);
            if(jobVacancy is not null)
            {
                var readFileQuery = new ReadFileQuery(new GetFileDTO { FileName = jobVacancy.Category.Photo, Folder = "CategoriesPhotos" });
                byte[] bytes = await _mediator.Send(readFileQuery, cancellationToken);
            }
            return Ok(jobVacancy);
        }

        [HttpGet("{jobId}/requirements")]
        public async Task<IActionResult> GetJobRequirements(int jobId, CancellationToken cancellationToken)
        {
            var getJobRequirementsQuery = new GetRequirementsByJobIdQuery(jobId);
            var jobRequirements = await _mediator.Send(getJobRequirementsQuery, cancellationToken);
            return Ok(jobRequirements);
        }

        [HttpPost("{jobId}/requirements")]
        public async Task<IActionResult> AddJobRequirement(int jobId, CreateRequirementDTO createRequirement, CancellationToken cancellationToken)
        {
            createRequirement.JobId = jobId;
            var createJobRequirementCommand = new CreateJobRequirementCommand(createRequirement);
            var jobRequirement = await _mediator.Send(createJobRequirementCommand, cancellationToken);
            return jobRequirement is not null ? Ok(jobRequirement.Id) : BadRequest("Can not add Job Requirement");
        }

        [HttpPut("{jobId}/requirements")]
        public async Task<IActionResult> UpdateJobRequirement(int jobId, UpdateRequirementDTO updateRequirement, CancellationToken cancellationToken)
        {
            updateRequirement.JobId = jobId;
            var updateJobRequireCommand = new UpdateJobRequirementCommand(updateRequirement);
            var updated = await _mediator.Send(updateJobRequireCommand, cancellationToken);
            return updated ? Ok() : BadRequest("Can not update Job Requirement");
        }

        [HttpDelete("{id}/requirements")]
        public async Task<IActionResult> DeleteJobRequirement(int id, CancellationToken token)
        {
            var deleteJobRequirementCommand = new DeleteJobRequirementCommand(id);
            var deleted = await _mediator.Send(deleteJobRequirementCommand, token);
            return deleted ? Ok() : BadRequest("Can not delete Job Requirement");
        }
        
        [HttpGet("{jobId}/responsibilites")]
        public async Task<IActionResult> GetJobResponsibilites(int jobId, CancellationToken cancellationToken)
        {
            var getJobResponsibilitesQuery = new GetJobResponsibilitesByJobIdQuery(jobId);
            var jobResponsibilites = await _mediator.Send(getJobResponsibilitesQuery, cancellationToken);
            return Ok(jobResponsibilites);
        }

        [HttpPost("{jobId}/responsibilty")]
        public async Task<IActionResult> AddJobResponsibility(int jobId, CreateResponsibilityDTO createResponsibility, CancellationToken cancellationToken)
        {
            var createJobResponsibility = new CreateJobResponsibilityCommand(createResponsibility);
            var responsibility = await _mediator.Send(createJobResponsibility, cancellationToken);
            return responsibility is not null ? Ok(responsibility.Id) : BadRequest("Can not add Job Responsibility");
        }

        [HttpDelete("{id}/responsibility")]
        public async Task<IActionResult> DeleteJobResponsibility(int id, CancellationToken cancellationToken)
        {
            var deleteJobResponsibilityCommand = new DeleteJobResponsibilityCommand(id);
            var deleted = await _mediator.Send(deleteJobResponsibilityCommand, cancellationToken);
            return deleted ? Ok() : BadRequest("Can not delete Job Responsibility");
        }

        [HttpPut("{jobId}/responsibility")]
        public async Task<IActionResult> UpdateJobResponsibility(int jobId, UpdateResponsibilityDTO updateResponsibility, CancellationToken cancellationToken)
        {
            var updateJobResponsibilityCommand = new UpdateJobResponsibilityCommand(updateResponsibility);
            var updated = await _mediator.Send(updateJobResponsibilityCommand, cancellationToken);
            return updated ? Ok() : BadRequest("Can not update Job Responsibility");
        }
    }
}
