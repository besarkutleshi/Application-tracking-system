using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class AplicantQuestion
    {
        public int Id { get; set; }
        public int? ApplicationId { get; set; }
        public int? UserId { get; set; }
        public int? AplicantProfileId { get; set; }
        public int? QuestionId { get; set; }
        public short? HasAnswer { get; set; }
        public string? Answer { get; set; }
        public int? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateNumber { get; set; }

        public virtual ApplicantProfile? AplicantProfile { get; set; }
        public virtual Application? Application { get; set; }
        public virtual Question? Question { get; set; }
        public virtual User? User { get; set; }
    }
}
