using System;
using System.Collections;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Interfaces.Researchers;
using Infrastructure.AdminModels;

namespace Infrastructure.Data {
    public class ResearcherAdminUnitOfWork : IResearcherAdminUnitOfWork {
        private readonly ResearcherAdminContext _context;
        private Hashtable _repositories;
        public ResearcherAdminUnitOfWork (ResearcherAdminContext context) {
            _context = context;
        }

        public async Task<int> Complete () {
            
            return await _context.SaveChangesAsync();
        }

        public void Dispose () {
            _context.Dispose();
        }

        public IResearcherAdminGenericRepository<TEntity> Repository<TEntity> () where TEntity : class {
           if (_repositories == null) _repositories = new Hashtable();
           var type = typeof(TEntity).Name;
           if(! _repositories.ContainsKey(type)){
               var repositoryType = typeof(ResearcherAdminGenericRepository<>);
               var repositoryInstance = Activator.CreateInstance(
                                       repositoryType.MakeGenericType(typeof(TEntity)), _context);
               _repositories.Add(type, repositoryInstance);

           }
           return (IResearcherAdminGenericRepository<TEntity>) _repositories[type];
        }
    }
}