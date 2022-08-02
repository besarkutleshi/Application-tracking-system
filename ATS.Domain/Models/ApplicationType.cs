using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class ApplicationType
    {
        public ApplicationType()
        {
            Applications = new HashSet<Application>();
            InputControls = new HashSet<InputControl>();
            Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public int? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateNumber { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<InputControl> InputControls { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
