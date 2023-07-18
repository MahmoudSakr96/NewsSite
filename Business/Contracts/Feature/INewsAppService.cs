using Business.Dto;
using Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts.Feature
{
    public interface INewsAppService
    {
        Task<NewsDto> AddAsync(NewsDto obj);
        Task<IEnumerable<NewsDto>> GetAllAsync();
        IEnumerable<NewsDto> GetAllByCategoryIdAsync(int Id);
        Task<NewsDto> GetByIdAsync(int id);
        Task<NewsDto> UpdateAsync(NewsDto obj);
        Task<NewsDto> DeleteByIdAsync(int id);

    }
}
