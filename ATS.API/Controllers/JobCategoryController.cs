using ATS.API.Services;
using ATS.Application.DTO_s.Applicant.Image;
using ATS.Application.DTO_s.OpenJob.JobCategory;
using ATS.Application.Features.Image.Queries.ReadFile;
using ATS.Application.Features.JobVacancy.JobCategory.Commads.CreateJobCategory;
using ATS.Application.Features.JobVacancy.JobCategory.Commads.DeleteJobCategory;
using ATS.Application.Features.JobVacancy.JobCategory.Commads.UpdateJobCategory;
using ATS.Application.Features.JobVacancy.JobCategory.Queries.GetJobCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ATS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobCategories(CancellationToken token)
        {
            var getJobCategoriesQuery = new GetJobCategoriesQuery();
            var categories = await _mediator.Send(getJobCategoriesQuery, token);
            if(categories.Count > 0)
            {
                foreach (var item in categories)
                {
                    var readFileQuery = new ReadFileQuery(new GetFileDTO { FileName = item.Photo, Folder = "CategoriesPhotos" });
                    byte[] bytes = await _mediator.Send(readFileQuery, token);
                    item.ImageBytes = bytes;
                }
            }
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> AddJobCategory([FromForm]CreateJobCategoryDTO createJobCategory, CancellationToken token)
        {
            var createJobCategoryCommand = new CreateJobCategoryCommand(createJobCategory);
            if(createJobCategory.PhotoFile is not null)
            {
                var fileName = await ImageService.AddImage(_mediator, new UploadImageDTO { File = createJobCategory.PhotoFile, Folder = "CategoriesPhotos" }, token);
                if (String.IsNullOrEmpty(fileName)) return BadRequest("Can not add Category Photo");

                createJobCategory.Photo = fileName;
            }

            var createdCategory = await _mediator.Send(createJobCategoryCommand, token);

            if(createdCategory is not null)
            {
                return Ok(createdCategory.Id);
            }
            
            if(createJobCategory.PhotoFile is not null)
            {
                await ImageService.DeleteImage(_mediator, createJobCategory.Photo, "CategoriesPhotos", token);
            }
            return BadRequest("Can not add Job Category");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJobCategory([FromForm]UpdateJobCategoryDTO updateJobCategory, CancellationToken token)
        {
            var updateJobCategoryCommand = new UpdateJobCategoryCommand(updateJobCategory);
            if(updateJobCategory.PhotoFile is not null)
            {
                var fileName = await ImageService.AddImage(_mediator, new UploadImageDTO { File = updateJobCategory.PhotoFile, Folder = "CategoriesPhotos" }, token);
                if (String.IsNullOrEmpty(fileName)) return BadRequest("Can not add Category Photo");

                updateJobCategory.Photo = fileName;
            }

            var updatedCategory = await _mediator.Send(updateJobCategoryCommand, token);

            if (updatedCategory)
            {
                await ImageService.DeleteImage(_mediator, updateJobCategory.LastImage, "CategoriesPhotos", token);
                return Ok();
            }

            if(updateJobCategory.PhotoFile is not null)
            {
                await ImageService.DeleteImage(_mediator, updateJobCategory.Photo, "CategoriesPhotos", token);
            }

            return BadRequest("Can not update Job Category");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobCategory(int id, CancellationToken token)
        {
            var deleteJobCategoryCommand = new DeleteJobCategoryCommand(id);
            var deletedCategory = await _mediator.Send(deleteJobCategoryCommand, token);
            return deletedCategory ? Ok() : BadRequest("Can not delete Job Category");
        }
    }
}
