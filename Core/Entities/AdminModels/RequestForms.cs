using System;
using System.Collections.Generic;

namespace Core.Entities.AdminModels
{
    public partial class RequestForms
    {
        public RequestForms()
        {
            AssignReviewers = new HashSet<AssignReviewers>();
            RequestActions = new HashSet<RequestActions>();
            RequestService = new HashSet<RequestService>();
            ResearchAttachments = new HashSet<ResearchAttachments>();
        }

        public int Id { get; set; }
        public string RequestNumber { get; set; }
        public string AppUserId { get; set; }
        public string ResearchTitle { get; set; }
        public string ResearchDescription { get; set; }
        public int ReseachCategoryId { get; set; }
        public int ServiceClassificationId { get; set; }
        public int ResearchLevelId { get; set; }
        public bool? PaymentApproved { get; set; }
        public DateTimeOffset? PaymentDate { get; set; }
        public decimal? PaymePaymentValue { get; set; }
        public string PaymentReference { get; set; }
        public int LanguageId { get; set; }
        public int TimingId { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedDateTime { get; set; }

        public virtual Languages Language { get; set; }
        public virtual ReseachCategories ReseachCategory { get; set; }
        public virtual ResearchLevels ResearchLevel { get; set; }
        public virtual ServiceClassifications ServiceClassification { get; set; }
        public virtual TimingRoutines Timing { get; set; }
        public virtual ICollection<AssignReviewers> AssignReviewers { get; set; }
        public virtual ICollection<RequestActions> RequestActions { get; set; }
        public virtual ICollection<RequestService> RequestService { get; set; }
        public virtual ICollection<ResearchAttachments> ResearchAttachments { get; set; }
    }
}
