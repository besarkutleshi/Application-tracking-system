using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class OpenJobsRequirement
    {
        public int Id { get; set; }
        public int? JobId { get; set; }
        public string? Requirement { get; set; }
        public string? RequirementEn { get; set; }
        public string? RequirementSr { get; set; }
        public string? Description { get; set; }
        public short? IsActive { get; set; }
        public int? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateNumber { get; set; }

        public virtual OpenJob? Job { get; set; }
    }
}
