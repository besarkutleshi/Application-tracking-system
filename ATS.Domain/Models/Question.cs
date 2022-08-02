using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class Question
    {
        public Question()
        {
            AplicantQuestions = new HashSet<AplicantQuestion>();
        }

        public int Id { get; set; }
        public string? Question1 { get; set; }
        public string? QuestionAlbanian { get; set; }
        public int? ApplicationTypeId { get; set; }
        public string? Description { get; set; }
        public int? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateNumber { get; set; }
        public string? Placeholder { get; set; }
        public string? PlaceHolderAlbania { get; set; }

        public virtual ApplicationType? ApplicationType { get; set; }
        public virtual ICollection<AplicantQuestion> AplicantQuestions { get; set; }
    }
}
