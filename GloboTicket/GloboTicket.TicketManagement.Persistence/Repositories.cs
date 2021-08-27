﻿using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Persistence
{/**
  * These list of repositories applied the Application Core contracts
  * */
    [GloboPersistenceService]
   public  class BaseRepository<T>:IAsyncRepository<T> where T : class
    {
        protected readonly GloboTicketDBcontext _dbcontext;
        public BaseRepository(GloboTicketDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async  Task<T> AddAsync(T entity)
        {
            await _dbcontext.Set<T>().AddAsync(entity);
            await _dbcontext.SaveChangesAsync();
            return entity;
        }

        public async  Task DeleteAsync(T entity)
        {
             _dbcontext.Set<T>().Remove(entity);
            await _dbcontext.SaveChangesAsync();
          
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbcontext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbcontext.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbcontext.Entry(entity).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            
        }
    }


    [GloboPersistenceService]
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        
        public CategoryRepository(GloboTicketDBcontext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents)
        {
            var allCategories = await _dbcontext.Categories.Include(x => x.Events).ToListAsync();
            if (!includePassedEvents)
            {
                allCategories.ForEach(p => p.Events.ToList().RemoveAll(c => c.Date < DateTime.Today));
            }
            return allCategories;
        }
    }

    [GloboPersistenceService]
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(GloboTicketDBcontext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
        {
            var matches = _dbcontext.Events.Any(e => e.Name.Equals(name) && e.Date.Date.Equals(eventDate.Date));
            return Task.FromResult(matches);
        }
    }
    [GloboPersistenceService]
    public class OrderRepository : BaseRepository<Order>, IAsyncOrderRepository
    {
        public OrderRepository(GloboTicketDBcontext dbContext) : base(dbContext)
        {
        }
        //Will be using Odata for paging
        public async Task<List<Order>> GetPagedOrdersForMonth(DateTime date, int page, int size)
        {
            return await _dbcontext.Orders.Where(x => x.OrderPlaced.Month == date.Month && x.OrderPlaced.Year == date.Year)
                .Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        }

        public async Task<int> GetTotalCountOfOrdersForMonth(DateTime date)
        {
            return await _dbcontext.Orders.CountAsync(x => x.OrderPlaced.Month == date.Month && x.OrderPlaced.Year == date.Year);
        }
    }


}
