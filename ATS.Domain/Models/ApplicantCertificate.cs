using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class ApplicantCertificate
    {
        public int Id { get; set; }
        public int? ApplicantEducationId { get; set; }
        public string? CertificateName { get; set; }
        public int? UserId { get; set; }

        public virtual ApplicantEducation? ApplicantEducation { get; set; }
        public virtual User? User { get; set; }
    }
}
