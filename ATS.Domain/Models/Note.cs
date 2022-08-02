using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class Note
    {
        public int Id { get; set; }
        public int? ApplicationId { get; set; }
        public int? ApplicantProfileId { get; set; }
        public string? NoteText { get; set; }
        public int? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateNo { get; set; }

        public virtual ApplicantProfile? ApplicantProfile { get; set; }
        public virtual Application? Application { get; set; }
    }
}
