using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class JobCategory
    {
        public JobCategory()
        {
            Applications = new HashSet<Application>();
            OpenJobs = new HashSet<OpenJob>();
        }

        public int Id { get; set; }
        public string? Category { get; set; }
        public string? CategoryAlbania { get; set; }
        public short? IsActive { get; set; }
        public int? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateNumber { get; set; }
        public string? Photo { get; set; }
        public string? Departament { get; set; }
        public string? Division { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<OpenJob> OpenJobs { get; set; }
    }
}
