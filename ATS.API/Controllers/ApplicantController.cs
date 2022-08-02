using ATS.Application.DTO_s.Applicant;
using ATS.Application.DTO_s.Applicant.Education;
using ATS.Application.DTO_s.Applicant.Experiences;
using ATS.Application.DTO_s.Applicant.Image;
using ATS.Application.DTO_s.Applicant.Languages;
using ATS.Application.DTO_s.Applicant.Profile;
using ATS.Application.DTO_s.Applicant.Skill;
using ATS.Application.Features.Applicant.ApplicantEducation.Commands.AddEducationCertificate;
using ATS.Application.Features.Applicant.ApplicantEducation.Commands.CreateEducation;
using ATS.Application.Features.Applicant.ApplicantEducation.Commands.DeleteEducation;
using ATS.Application.Features.Applicant.ApplicantEducation.Commands.DeleteEducationCertificate;
using ATS.Application.Features.Applicant.ApplicantEducation.Commands.UpdateEducation;
using ATS.Application.Features.Applicant.ApplicantEducation.Queries.GetEducationByUserId;
using ATS.Application.Features.Applicant.ApplicantLanguages.Commands.CreateApplicantLanguage;
using ATS.Application.Features.Applicant.ApplicantLanguages.Commands.DeleteApplicantLanguage;
using ATS.Application.Features.Applicant.ApplicantLanguages.Commands.UpdateApplicantLanguage;
using ATS.Application.Features.Applicant.ApplicantLanguages.Queries.GetApplicantLanguageByUserId;
using ATS.Application.Features.Applicant.ApplicantProfile.Commands.CreateProfile;
using ATS.Application.Features.Applicant.ApplicantProfile.Commands.InsertImage;
using ATS.Application.Features.Applicant.ApplicantProfile.Commands.UpdateProfile;
using ATS.Application.Features.Applicant.ApplicantProfile.Querie_s;
using ATS.Application.Features.Applicant.ApplicantProfile.Querie_s.GetApplicantProfiles;
using ATS.Application.Features.Applicant.ApplicantSkills.Commands.CreateApplicantSkill;
using ATS.Application.Features.Applicant.ApplicantSkills.Commands.DeleteApplicantSkill;
using ATS.Application.Features.Applicant.ApplicantSkills.Commands.UpdateApplicantSkill;
using ATS.Application.Features.Applicant.ApplicantSkills.Queries.GetApplicantSkillByUserId;
using ATS.Application.Features.Applicant.ApplicantWorkExperience.Commands.CreateWorkExperience;
using ATS.Application.Features.Applicant.ApplicantWorkExperience.Commands.DeleteWorkExperience;
using ATS.Application.Features.Applicant.ApplicantWorkExperience.Commands.DeleteWorkExperienceCertificate;
using ATS.Application.Features.Applicant.ApplicantWorkExperience.Commands.UpdateWorkExperience;
using ATS.Application.Features.Applicant.ApplicantWorkExperience.Queries.GetExperiencesByUserId;
using ATS.Application.Features.Image.Commands.DeleteImage;
using ATS.Application.Features.Image.Commands.UploadImage;
using ATS.Application.Features.Image.Queries.GetFile;
using ATS.Application.Features.Image.Queries.ReadFile;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ATS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public ApplicantController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        #region applicant profile

        [HttpPost]
        public async Task<IActionResult> CreateProfile(CreateApplicantProfileDto createApplicantProfile, CancellationToken token)
        {
            var command = new CreateProfileCommand(createApplicantProfile);
            var created = await _mediatR.Send(command, token);
            return created != null ? Ok(created.Id) : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProfile([FromForm]UpdateApplicantProfileDto updateApplicantProfile, CancellationToken token)
        {
            bool updated = false;
            var command = new UpdateProfileCommand(updateApplicantProfile);
            if(updateApplicantProfile.PhotoFile == null)
            {
                updateApplicantProfile.Photo = updateApplicantProfile.LastImageName;
                updated = await _mediatR.Send(command, token);
                return updated ? Ok() : BadRequest("Can not update profile.");
            }

            string imageName = await AddImage(
                new UploadImageDTO { File = updateApplicantProfile.PhotoFile, Folder = "Images", UserId = updateApplicantProfile.UserId }, token);
            if(imageName == null) return BadRequest("Can not insert image.");

            updateApplicantProfile.Photo = imageName;
            updated = await _mediatR.Send(command, token);

            if (!updated)
            {
                await DeleteImage(imageName, "Images", token);
                return BadRequest("Can not update profile.");
            }

            if (!String.IsNullOrEmpty(updateApplicantProfile.LastImageName))
            {
                await DeleteImage(updateApplicantProfile.LastImageName, "Images", token);
            }
            return Ok();
        }

        [HttpPost("{profileId}/{userId}/image")]
        public async Task<IActionResult> InsertImage(int profileId, int userId, [FromForm] IFormFile file, CancellationToken token)
        {
            var uploaded = await AddImage(new UploadImageDTO { File = file, Folder = "Images", UserId = userId }, token);
            if (uploaded != null)
            {
                var insertCommand = new InsertImageCommand(new InsertImageDTO { ImageName = uploaded, ProfileId = profileId });
                var inserted = await _mediatR.Send(insertCommand, token);
                return inserted ? Ok() : BadRequest("Image not inserted.");
            }
            return BadRequest("Can not upload image.");
        }

        [HttpGet]
        public async Task<IActionResult> GetProfiles(CancellationToken token)
        {
            var getProfilesQuery = new GetApplicantProfilesQuery();
            var profiles = await _mediatR.Send(getProfilesQuery, token);
            return Ok(profiles);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetProfile(int userId, CancellationToken token)
        {
            var getProfileQuery = new GetApplicantProfileQuery(userId);
            var profile = await _mediatR.Send(getProfileQuery, token);
            if (!String.IsNullOrEmpty(profile.Photo))
            {
                var readFileQuery = new ReadFileQuery(new GetFileDTO { FileName = profile.Photo, Folder = "Images" });
                byte[] bytes = await _mediatR.Send(readFileQuery, token);
                profile.ImageBytes = bytes;
            }
            return Ok(profile);
        }

#endregion

        #region applicant education

        [HttpPost("{userId}/education")]
        public async Task<IActionResult> AddEducation(int userId, [FromForm]CreateEducationDTO createEducation, CancellationToken token)
        {
            createEducation.UserId = userId;
            string fileName = "";
            var createEducationCommand = new CreateEducationCommand(createEducation);
            if(createEducation.Certificate != null)
            {
                fileName = await AddImage(new UploadImageDTO { File = createEducation.Certificate, Folder = "Certificates", UserId = userId }, token);
                if (!String.IsNullOrEmpty(fileName))
                {
                    createEducation.ApplicantCertificates.Add(new EducationCertificateDTO { CertificateName = fileName, UserId = userId });
                }
            }
            var created = await _mediatR.Send(createEducationCommand, token);
            if(created == null)
            {
                await DeleteImage(fileName, "Certificates", token);
                return BadRequest("Can not insert education.");
            }
            return created != null ? Ok(created.Id) : BadRequest("Can not insert education.");
        }

        [HttpDelete("{id}/education")]
        public async Task<IActionResult> DeleteEducation(int id, CancellationToken token)
        {
            var deleteEducationCommand = new DeleteEducationCommand(id);
            var deleted = await _mediatR.Send(deleteEducationCommand, token);
            return deleted ? Ok() : BadRequest("Can not delete education.");
        }

        [HttpPut("{id}/education")]
        public async Task<IActionResult> UpdateEducation(int id, [FromForm]UpdateEducationDTO updateEducation, CancellationToken token)
        {
            string fileName = "";
            var updateEducationCommand = new UpdateEducationCommand(updateEducation);
            if (updateEducation.Certificate != null)
            {
                fileName = await AddImage(new UploadImageDTO { File = updateEducation.Certificate, Folder = "Certificates", UserId = updateEducation.UserId }, token);
                if (!String.IsNullOrEmpty(fileName))
                {
                    updateEducation.ApplicantCertificates.Add(
                        new EducationCertificateDTO { CertificateName = fileName, UserId = updateEducation.UserId, ApplicantEducationId = updateEducation.Id });
                }
            }
            var updated = await _mediatR.Send(updateEducationCommand, token);
            if (!updated)
            {
                await DeleteImage(fileName, "Certificates", token);
                return BadRequest("Can not update education.");
            }
            return updated ? Ok() : BadRequest("Can not update education.");
        }

        [HttpGet("{userId}/education")]
        public async Task<IActionResult> GetEducationsByUserId(int userId, CancellationToken token)
        {
            var getEducationByUserIdQuery = new GetEducationByUserIdQuery(userId);
            var list = await _mediatR.Send(getEducationByUserIdQuery, token);
            return Ok(list);
        }

        [HttpDelete("{educationId}/certificate/education")]
        public async Task<IActionResult> DeleteEducationCertificate(int educationId, CancellationToken token)
        {
            var deleteEducationCertificateCommand = new DeleteEducationCertificateCommand(educationId);
            var deleted = await _mediatR.Send(deleteEducationCertificateCommand, token);
            if(deleted != null && deleted != "")
            {
                await DeleteImage(deleted, "Certificates", token);
                return Ok();
            }
            return BadRequest("Can not delete education certificate.");
        }

        [HttpPost("{educationId}/certificate/education")]
        public async Task<IActionResult> AddEducationCertificate([FromForm]EducationCertificateDTO educationCertificateDTO, CancellationToken token)
        {
            if(educationCertificateDTO.Certificate != null)
            {
                var uploadImage = await AddImage(new UploadImageDTO
                {
                    File = educationCertificateDTO.Certificate,
                    Folder = "Certificates",
                    UserId = educationCertificateDTO.UserId
                }, token);

                if (uploadImage != null && uploadImage != "")
                {
                    educationCertificateDTO.CertificateName = uploadImage;
                }
            }
            var addEducationCertificateCommand = new AddEducationCertificateCommand(educationCertificateDTO);
            var added = await _mediatR.Send(addEducationCertificateCommand, token);
            return added ? Ok() : BadRequest("Can not add education certificate.");
        }

        [HttpGet("{certificateName}/certificate/education")]
        public async Task<IActionResult> DownloadEducationCertificate(string certificateName, CancellationToken cancellationToken)
        {
            var getFileQuery = new GetFileQuery(new GetFileDTO { FileName = certificateName, Folder = "Certificates" });
            return await _mediatR.Send(getFileQuery, cancellationToken);
        }

        #endregion

        #region applicant experience 
        [HttpPost("{userId}/experience")]
        public async Task<IActionResult> AddExperience(int userId, [FromForm]CreateWorkExperienceDTO createWorkExperience, CancellationToken cancellationToken)
        {
            string fileName = "";
            if(createWorkExperience.Certificate is not null)
            {
                fileName = await AddImage(
                    new UploadImageDTO { File = createWorkExperience.Certificate, Folder = "ExperienceCertificates", UserId = userId }, cancellationToken);
                if (String.IsNullOrEmpty(fileName)) throw new Exception("Can not add experience certificate");

                createWorkExperience.FileName = fileName;
            }

            var createExperienceCommand = new CreateWorkExperienceCommand(createWorkExperience);
            var experience = await _mediatR.Send(createExperienceCommand, cancellationToken);
            
            if(experience is null)
            {
                await DeleteImage(fileName, "ExperienceCertificates", cancellationToken);
                return BadRequest("Can not add experience");
            }

            return Ok(experience.Id);
        }

        [HttpPut("{userId}/experience")]
        public async Task<IActionResult> UpdateExperience(int userId, [FromForm]UpdateWorkExperienceDTO updateWorkExperience, CancellationToken token)
        {
            string fileName = "";
            if(updateWorkExperience.Certificate is not null)
            {
                fileName = await AddImage(
                    new UploadImageDTO { File = updateWorkExperience.Certificate, Folder = "ExperienceCertificates", UserId = userId }, token);
                if (String.IsNullOrEmpty(fileName)) throw new Exception("Can not add experience certificate");

                updateWorkExperience.FileName = fileName;
            }

            var updateExperienceCommand = new UpdateWorkExperienceCommand(updateWorkExperience);
            var updated = await _mediatR.Send(updateExperienceCommand, token);

            if (updated)
            {
                if (!String.IsNullOrEmpty(updateWorkExperience.LastFileName)) await DeleteImage(updateWorkExperience.LastFileName, "ExperienceCertificates", token);
                return Ok();
            }

            await DeleteImage(fileName, "ExperienceCertificates", token);
            return BadRequest("Can not update experience");
        }

        [HttpDelete("{experienceId}/experience")]
        public async Task<IActionResult> DeleteExperience(int experienceId, CancellationToken token)
        {
            var deleteWorkExperienceCommand = new DeleteWorkExperienceCommand(experienceId);
            var deleted = await _mediatR.Send(deleteWorkExperienceCommand, token);
            return deleted ? Ok() : BadRequest("Can not delete experience");
        }

        [HttpGet("{userId}/experience")]
        public async Task<IActionResult> GetExperiencesByUserId(int userId, CancellationToken token)
        {
            var getExperiencesByUserIdQuery = new GetExperiencesByUserIdQuery(userId);
            var list = await _mediatR.Send(getExperiencesByUserIdQuery, token);
            return Ok(list);
        }

        [HttpDelete("{experienceId}/certificate/experience")]
        public async Task<IActionResult> DeleteExperienceCertificate(int experienceId, CancellationToken token)
        {
            var deleteExperienceCertificateCommand = new DeleteWorkExperienceCertificateCommand(experienceId);
            var deleted = await _mediatR.Send(deleteExperienceCertificateCommand, token);

            if (String.IsNullOrEmpty(deleted)) throw new Exception("Can not delete experience certificate");

            await DeleteImage(deleted, "ExperienceCertificates", token);

            return Ok();
        }

        [HttpGet("{certificateName}/certificate/experience")]
        public async Task<IActionResult> DownloadExperienceCertificate(string certificateName, CancellationToken cancellationToken)
        {
            var getFileQuery = new GetFileQuery(new GetFileDTO { FileName = certificateName, Folder = "ExperienceCertificates" });
            return await _mediatR.Send(getFileQuery, cancellationToken);
        }

        #endregion

        #region applicant language

        [HttpPost("{userId}/language")]
        public async Task<IActionResult> AddLanguage(CreateLanguageDTO createLanguage, CancellationToken token)
        {
            var createLanguageCommand = new CreateLanguageCommand(createLanguage);
            var language = await _mediatR.Send(createLanguageCommand, token);
            return language is not null ? Ok(language) : BadRequest("Can not add language");
        }

        [HttpDelete("{languageId}/language")]
        public async Task<IActionResult> DeleteLanguage(int languageId, CancellationToken token)
        {
            var deleteLanguageCommand = new DeleteLangaugeCommand(languageId);
            var deleted = await _mediatR.Send(deleteLanguageCommand, token);
            return deleted ? Ok() : BadRequest("Can not delete language");
        }

        [HttpPut("{userId}/language")]
        public async Task<IActionResult> UpdateLanguage(UpdateLanguageDTO updateLanguage, CancellationToken token)
        {
            var updateLanguageCommand = new UpdateLanguageCommand(updateLanguage);
            var updated = await _mediatR.Send(updateLanguageCommand, token);
            return updated ? Ok() : BadRequest("Can not update language");
        }

        [HttpGet("{userId}/language")]
        public async Task<IActionResult> GetLanguagesByUserId(int userId, CancellationToken token)
        {
            var getLangaugesByUserIdQuery = new GetApplicantLanguageByUserIdQuery(userId);
            var languages = await _mediatR.Send(getLangaugesByUserIdQuery, token);
            return Ok(languages);
        }

        #endregion

        #region applicant skills

        [HttpPost("{userId}/skills")]
        public async Task<IActionResult> AddSkill(CreateSkillDTO createSkill, CancellationToken token)
        {
            var createSkillCommand = new CreateSkillCommand(createSkill);
            var skill = await _mediatR.Send(createSkillCommand, token);
            return skill is not null ? Ok(skill.Id) : BadRequest("Can not add skill");
        }

        [HttpDelete("{skillId}/skills")]
        public async Task<IActionResult> DeleteSkill(int skillId, CancellationToken token)
        {
            var deleteSkillCommand = new DeleteSkillCommand(skillId);
            var deleted = await _mediatR.Send(deleteSkillCommand, token);
            return deleted ? Ok() : BadRequest("Can not delete skill");
        }

        [HttpPut("{userId}/skills")]
        public async Task<IActionResult> UpdateSkill(UpdateSkillDTO updateSkill, CancellationToken token)
        {
            var updateSkillCommand = new UpdateSkillCommand(updateSkill);
            var updated = await _mediatR.Send(updateSkillCommand, token);
            return updated ? Ok() : BadRequest("Can not update skill");
        }

        [HttpGet("{userId}/skills")]
        public async Task<IActionResult> GetSkillsByUserId(int userId, CancellationToken token)
        {
            var getSkillsQuery = new GetSkillsByUserIdQuery(userId);
            var list = await _mediatR.Send(getSkillsQuery, token);
            return Ok(list);
        }

        #endregion

        private async Task<bool> DeleteImage(string fileName, string folder, CancellationToken token)
        {
            var deleteImageCommand = new DeleteImageCommand(new DeleteImageDTO { FileName = fileName, Folder = folder });
            return await _mediatR.Send(deleteImageCommand, token);
        }

        private async Task<string> AddImage(UploadImageDTO uploadImage, CancellationToken token)
        {
            var uploadCommand = new UploadImageCommand(uploadImage);
            return await _mediatR.Send(uploadCommand, token);
        }
    }
}
