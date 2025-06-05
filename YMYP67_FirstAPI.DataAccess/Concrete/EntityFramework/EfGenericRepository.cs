using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YMYP67_FirstAPI.DataAccess.Abstract;
using YMYP67_FirstAPI.Entities.Abstract;

namespace YMYP67_FirstAPI.DataAccess.Concrete.EntityFramework;
public class EfGenericRepository<T> : IEntityRepository<T> where T : class, IEntity, new()
{
    private FirstApiContext _context;
    private DbSet<T> _dbSet;

    public EfGenericRepository(FirstApiContext context)
    {
        _context = context;
        _dbSet= _context.Set<T>();
    }
    public void Add(T entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
        _context.SaveChanges();
    }

    public T Get(Expression<Func<T, bool>> filter)
    {
        return _dbSet.FirstOrDefault(filter);
    }

    public List<T> GetAll(Expression<Func<T, bool>> filter = null)
    {
        return filter == null ? _dbSet.ToList() : _dbSet.Where(filter).ToList(); 
    }

    public IQueryable<T> GetAllQueryable(Expression<Func<T, bool>>? filter = null)
    {
        return filter == null ? _dbSet : _dbSet.Where(filter).AsQueryable();
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
        _context.SaveChanges();
    }
}

