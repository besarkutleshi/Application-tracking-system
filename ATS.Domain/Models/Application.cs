using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class Application
    {
        public Application()
        {
            AplicantQuestions = new HashSet<AplicantQuestion>();
            ApplicationStatusLogs = new HashSet<ApplicationStatusLog>();
            Interviews = new HashSet<Interview>();
            Notes = new HashSet<Note>();
            Offers = new HashSet<Offer>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? AplicantProfileId { get; set; }
        public int? OpenJobId { get; set; }
        public int? ApplicationTypeId { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public string? Status { get; set; }
        public int? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateNumber { get; set; }
        public int? CategoryId { get; set; }

        public virtual ApplicantProfile? AplicantProfile { get; set; }
        public virtual ApplicationType? ApplicationType { get; set; }
        public virtual JobCategory? Category { get; set; }
        public virtual OpenJob? OpenJob { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<AplicantQuestion> AplicantQuestions { get; set; }
        public virtual ICollection<ApplicationStatusLog> ApplicationStatusLogs { get; set; }
        public virtual ICollection<Interview> Interviews { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
    }
}
