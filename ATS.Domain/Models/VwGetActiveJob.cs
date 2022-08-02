using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class VwGetActiveJob
    {
        public string? OpenJobName { get; set; }
        public int? ApplicationsNumber { get; set; }
        public int Id { get; set; }
        public string? JobName { get; set; }
        public string? JobNameEn { get; set; }
        public string? JobNameSr { get; set; }
        public string? Departament { get; set; }
        public string? Division { get; set; }
        public string? JobLocation { get; set; }
        public int? NoEmployeesWanted { get; set; }
        public string? JobType { get; set; }
        public string? ExperienceLevel { get; set; }
        public DateTime? ExpireDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Description { get; set; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionSr { get; set; }
        public short? IsActive { get; set; }
        public int? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateNumber { get; set; }
        public string Status { get; set; } = null!;
        public short? IsRemote { get; set; }
        public int? RemainingDays { get; set; }
        public int? CategoryId { get; set; }
        public string? Photo { get; set; }
    }
}
