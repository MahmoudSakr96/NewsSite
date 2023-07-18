using Business.Dto;
using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts.Persistence.IRepository
{
    public interface IAsyncRepository<T> where T : Auditing
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int Id);
        Task<T> AddAsync(T Obj);
        Task<T> UpdateAsync(T Obj);

        Task<T> DeleteAsync(T Obj);

        Task<T> DeleteAsync(int Id);
        IEnumerable<News> GetAllByCategoryIdAsync(int Id);


    }
}
