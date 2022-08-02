using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class ApplicantProfile
    {
        public ApplicantProfile()
        {
            AplicantQuestions = new HashSet<AplicantQuestion>();
            ApplicantEducations = new HashSet<ApplicantEducation>();
            ApplicantLanguages = new HashSet<ApplicantLanguage>();
            ApplicantSkills = new HashSet<ApplicantSkill>();
            ApplicantWorkExperiences = new HashSet<ApplicantWorkExperience>();
            Applications = new HashSet<Application>();
            Notes = new HashSet<Note>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? MiddleName { get; set; }
        public string? PersonalNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public string? CurrentCountry { get; set; }
        public string? BirthCountry { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Gender { get; set; }
        public string? Status { get; set; }
        public string? Photo { get; set; }
        public string? Description { get; set; }
        public short? IsActive { get; set; }
        public int? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateNumber { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<AplicantQuestion> AplicantQuestions { get; set; }
        public virtual ICollection<ApplicantEducation> ApplicantEducations { get; set; }
        public virtual ICollection<ApplicantLanguage> ApplicantLanguages { get; set; }
        public virtual ICollection<ApplicantSkill> ApplicantSkills { get; set; }
        public virtual ICollection<ApplicantWorkExperience> ApplicantWorkExperiences { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
