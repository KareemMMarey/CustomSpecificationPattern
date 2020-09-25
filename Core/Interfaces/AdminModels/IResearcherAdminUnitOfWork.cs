using System;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Researchers;

namespace Core.Interfaces
{
    public interface IResearcherAdminUnitOfWork : IDisposable
    {
         IResearcherAdminGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
         Task<int> Complete();
    }
}