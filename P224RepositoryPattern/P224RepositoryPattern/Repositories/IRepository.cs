using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P224RepositoryPattern.Repositories
{
    public interface IRepository<TEntity>
    {
        Task AddAsync(TEntity entity);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetAsync(int id);

        Task<int> CommitAsync();

        int Commit();

        void Remove(TEntity entity);

        Task<bool> AnyAsync(int id);
    }
}
