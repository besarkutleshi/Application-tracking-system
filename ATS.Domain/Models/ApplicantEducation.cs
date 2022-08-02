using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class ApplicantEducation
    {
        public ApplicantEducation()
        {
            ApplicantCertificates = new HashSet<ApplicantCertificate>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? AplicantProfileId { get; set; }
        public string? Institution { get; set; }
        public string? Direction { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public short? OnGoing { get; set; }
        public string? Description { get; set; }
        public short? IsActive { get; set; }
        public int? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateNumber { get; set; }

        public virtual ApplicantProfile? AplicantProfile { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<ApplicantCertificate> ApplicantCertificates { get; set; }
    }
}
