﻿using Microsoft.EntityFrameworkCore;
using Trucks.Domain.Entities;
using Trucks.Domain.Repositories;
using Trucks.Infra.Context;
namespace Trucks.Infra.Repositories;

public class Repository<T>(DbContextTrucks _dbContext) : IRepository<T> where T : BaseEntity
{

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbContext.AddAsync(entity, cancellationToken);
    }

    public void Delete(T entity)
    {
        _dbContext.Remove(entity);
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>().FindAsync(id, cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Update(T entity)
    {
        _dbContext.Update(entity);
    }
}
