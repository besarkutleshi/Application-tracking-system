using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class ApplicationStatusLog
    {
        public int Id { get; set; }
        public int? ApplicationId { get; set; }
        public string? Status { get; set; }
        public DateTime? ChangeDate { get; set; }
        public int? ChangeBy { get; set; }
        public string? Description { get; set; }

        public virtual Application? Application { get; set; }
    }
}
