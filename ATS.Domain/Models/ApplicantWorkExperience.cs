using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class ApplicantWorkExperience
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ApplicantProfileId { get; set; }
        public string? Institution { get; set; }
        public string? Position { get; set; }
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
        public string? FileName { get; set; }

        public virtual ApplicantProfile? ApplicantProfile { get; set; }
        public virtual User? InsertByNavigation { get; set; }
        public virtual User? UpdateByNavigation { get; set; }
        public virtual User? User { get; set; }
    }
}
