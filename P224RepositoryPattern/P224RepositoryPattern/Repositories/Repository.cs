using Microsoft.EntityFrameworkCore;
using P224RepositoryPattern.Data.DAL;
using P224RepositoryPattern.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P224RepositoryPattern.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity:BaseEntity
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().Where(c => !c.IsDeleted).ToListAsync();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(c => !c.IsDeleted && c.Id == id);
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await _context.Set<TEntity>().AnyAsync(c => !c.IsDeleted && c.Id == id);
        }
    }
}
