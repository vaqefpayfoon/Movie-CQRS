
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Movie.Core;

namespace Movie.Infrastructure;

public interface IRepository<T> where T : BaseEntity
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}