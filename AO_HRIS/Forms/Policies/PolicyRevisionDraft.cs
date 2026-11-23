using System;

namespace AO_HRIS.Forms.Policies
{
    public sealed class PolicyRevisionDraft
    {
        public int? PolicyId { get; set; }
        public string PolicyCode { get; set; }
        public string PolicyTitle { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string RevisionLabel { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string OriginalFileName { get; set; }
        public byte[] FileData { get; set; }
    }
}
