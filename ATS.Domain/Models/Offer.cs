using System;
using System.Collections.Generic;

namespace ATS.Domain.Models
{
    public partial class Offer
    {
        public int Id { get; set; }
        public int? ApplicationId { get; set; }
        public string? Offer1 { get; set; }
        public DateTime? OfferExpire { get; set; }
        public int? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public short? IsConfirmed { get; set; }
        public string? Description { get; set; }
        public DateTime? ConfrimDate { get; set; }

        public virtual Application? Application { get; set; }
    }
}
