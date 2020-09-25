using System;
using System.Collections.Generic;

namespace Core.Entities.AdminModels
{
    public partial class ActionInRule
    {
        public ActionInRule()
        {
            RequestActions = new HashSet<RequestActions>();
        }

        public int Id { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }
        public string ActionType { get; set; }

        public virtual ICollection<RequestActions> RequestActions { get; set; }
    }
}
