using System.Linq;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ResearcherAdminSpecificationEvaluator<TEntity> where TEntity: class
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
        ISpecification<TEntity> spec
        )
        {
            var query = inputQuery;
            if(spec.Criteria != null){
                query = query.Where(spec.Criteria);
            }  
            if(spec.OrderBy != null){
                query = query.OrderBy(spec.OrderBy);
            } 
            if(spec.OrderByDecending != null){
                query = query.OrderByDescending(spec.OrderByDecending);
            } 
            if(spec.IsPagingEnabled){
                query = query.Skip(spec.Skip).Take(spec.Take);
               
            }
            query = spec.Includes.Aggregate(query, (current, include)=>current.Include(include));
            if(spec.IncludeStrings?.Count>0){
                query = spec.IncludeStrings.Aggregate(query,
                                    (current, include) => current.Include(include));
            }
            

            return query;
        }
    }
}