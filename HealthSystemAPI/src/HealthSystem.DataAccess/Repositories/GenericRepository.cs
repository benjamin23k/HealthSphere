using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PatientSystem.Domain.Common;
using PatientSystem.Domain.Interfaces;

namespace PatientSystem.DataAccess.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly PatientSystemDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public GenericRepository(PatientSystemDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public virtual async Task<TEntity?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();

    public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate) =>
        await _dbSet.Where(predicate).ToListAsync();

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public virtual void Update(TEntity entity) => _dbSet.Update(entity);

    public virtual void Remove(TEntity entity) => _dbSet.Remove(entity);

    public virtual async Task<bool> ExistsAsync(int id) => await _dbSet.AnyAsync(e => e.Id == id);
}
