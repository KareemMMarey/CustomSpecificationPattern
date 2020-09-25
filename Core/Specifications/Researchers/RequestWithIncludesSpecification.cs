using System;
using System.Linq.Expressions;
using Core.Entities.AdminModels;
using System.Linq;

namespace Core.Specifications
{
    public class RequestWithIncludesSpecification : BaseSpecification<RequestForms>
    {
        
        public RequestWithIncludesSpecification(int id) : 
        base(o => o.Id == id)
        {
        }
        public RequestWithIncludesSpecification( string userId) : 
        base(o => o.AppUserId == userId)
        {
            AddInclude(r => r.RequestActions);
            AddInclude($"{nameof(RequestForms.RequestActions)}.{nameof(RequestActions.Action)}");
        }
    }
}