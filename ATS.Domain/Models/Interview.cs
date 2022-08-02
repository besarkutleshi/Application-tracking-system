using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class Interview
    {
        public Interview()
        {
            InterviewDates = new HashSet<InterviewDate>();
        }

        public int Id { get; set; }
        public int? ApplicationId { get; set; }
        public DateTime? InterviewDate { get; set; }
        public int? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public string? Description { get; set; }
        public short? IsConfirmed { get; set; }

        public virtual Application? Application { get; set; }
        public virtual ICollection<InterviewDate> InterviewDates { get; set; }
    }
}
