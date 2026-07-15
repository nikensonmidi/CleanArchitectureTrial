using DodoBed.Manufacturing.Application.Interfaces.Persistence;
using DodoBed.Manufacturing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DodoBed.Manufacturing.SqlPersistence
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly DodoBedManufacturingContext _dbContext;

        public BaseRepository(DodoBedManufacturingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public async  Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public T Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
             _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;

        }
    }

    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly DodoBedManufacturingContext _dbContext;
        public ProductRepository(DodoBedManufacturingContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async  Task<bool> IsDescriptionUnique(string description)
        {
            return _dbContext.Products.Any(e => e.Description.Trim().ToLower() == description.Trim().ToLower());

        }

        public async  Task<bool> IsNameUnique(string name)
        {
            return _dbContext.Products.Any(e => e.Name.Trim().ToLower() == e.Name.Trim().ToLower());
        }
    }
}
