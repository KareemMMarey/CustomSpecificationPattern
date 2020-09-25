using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Researchers;
using Core.Specifications;
using Infrastructure.AdminModels;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ResearcherAdminGenericRepository<T> : IResearcherAdminGenericRepository<T> where T : class
    {
        private readonly ResearcherAdminContext _context;

        public ResearcherAdminGenericRepository(ResearcherAdminContext context)
        {
           _context = context;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

       

        //Here we can't get the include property to get the navigation properties
        //So we will use the specification pattern
        //specification pattern
        //descripe a query in an object 
        //retuens an Iquerable <T>
        //Generic list method takes specification as a parameter

        //Specification , I need all products with red in name and return all brands and types
        //ListAsync(Specification)

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }
         public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }
        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return ResearcherAdminSpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(),spec);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void Detatch(T entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
            //_context.Set<T>().Remove(entity);
        }
    }
}