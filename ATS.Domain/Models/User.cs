using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class User
    {
        public User()
        {
            AplicantQuestions = new HashSet<AplicantQuestion>();
            ApplicantCertificates = new HashSet<ApplicantCertificate>();
            ApplicantEducations = new HashSet<ApplicantEducation>();
            ApplicantLanguages = new HashSet<ApplicantLanguage>();
            ApplicantProfiles = new HashSet<ApplicantProfile>();
            ApplicantSkills = new HashSet<ApplicantSkill>();
            ApplicantWorkExperienceInsertByNavigations = new HashSet<ApplicantWorkExperience>();
            ApplicantWorkExperienceUpdateByNavigations = new HashSet<ApplicantWorkExperience>();
            ApplicantWorkExperienceUsers = new HashSet<ApplicantWorkExperience>();
            Applications = new HashSet<Application>();
            LoginLogs = new HashSet<LoginLog>();
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Description { get; set; }
        public short? IsActive { get; set; }
        public int? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateNumber { get; set; }
        public short? IsConfirmed { get; set; }
        public int? EmpId { get; set; }

        public virtual ICollection<AplicantQuestion> AplicantQuestions { get; set; }
        public virtual ICollection<ApplicantCertificate> ApplicantCertificates { get; set; }
        public virtual ICollection<ApplicantEducation> ApplicantEducations { get; set; }
        public virtual ICollection<ApplicantLanguage> ApplicantLanguages { get; set; }
        public virtual ICollection<ApplicantProfile> ApplicantProfiles { get; set; }
        public virtual ICollection<ApplicantSkill> ApplicantSkills { get; set; }
        public virtual ICollection<ApplicantWorkExperience> ApplicantWorkExperienceInsertByNavigations { get; set; }
        public virtual ICollection<ApplicantWorkExperience> ApplicantWorkExperienceUpdateByNavigations { get; set; }
        public virtual ICollection<ApplicantWorkExperience> ApplicantWorkExperienceUsers { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<LoginLog> LoginLogs { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
