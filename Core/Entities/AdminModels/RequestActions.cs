using System;
using System.Collections.Generic;

namespace Core.Entities.AdminModels
{
    public partial class RequestActions
    {
        public int Id { get; set; }
        public int ActionId { get; set; }
        public string Notes { get; set; }
        public string TakenBy { get; set; }
        public DateTimeOffset ActionDate { get; set; }
        public int? RequestFormId { get; set; }

        public virtual ActionInRule Action { get; set; }
        public virtual RequestForms RequestForm { get; set; }
    }
}
