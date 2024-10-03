
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movie.Core;

namespace Movie.Infrastructure;

public class Repository<T>: IRepository<T>  where T: BaseEntity
{
    private MovieContext _context;
    public DbSet<T> _db;
    public Repository(MovieContext context)
    {
        _context = context;
        _db = context.Set<T>();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _db.ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        var result = await _db.FindAsync(id);
        if(result is not null)
            return result;
        else
            throw new NotImplementedException();
    }

    public async Task<T> AddAsync(T entity)
    {
        entity.CreateDateTime = DateTime.Now;
        await _db.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _db.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _db.Remove(entity);
        await _context.SaveChangesAsync();
    }
}