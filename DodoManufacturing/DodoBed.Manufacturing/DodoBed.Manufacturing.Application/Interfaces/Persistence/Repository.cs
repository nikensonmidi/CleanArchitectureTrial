using DodoBed.Manufacturing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodoBed.Manufacturing.Application.Interfaces.Persistence
{
    public interface IRepository<T> where T: class
    {

        IEnumerable<T>  GetAll();
        T Add(T entity);
        Task<T> AddAsync(T entity);
        void Delete(T entity);
        Task DeleteAsync(T entity);
        T Update(T entity);
        Task<T> UpdateAsync(T entity);

    }

    public interface IProductRepository:IRepository<Product>
    {
       
    }


}
