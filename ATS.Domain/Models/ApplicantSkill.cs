using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class ApplicantSkill
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? AplicantProfileId { get; set; }
        public string? Skill { get; set; }
        public string? KnowledgeLevel { get; set; }
        public short? IsActive { get; set; }
        public int? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateNumber { get; set; }

        public virtual ApplicantProfile? AplicantProfile { get; set; }
        public virtual User? User { get; set; }
    }
}
