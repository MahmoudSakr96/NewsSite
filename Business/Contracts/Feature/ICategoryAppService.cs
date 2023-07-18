using Business.Dto;
using Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts.Feature
{
    public interface ICategoryAppService
    {
        Task<CategoryDto> AddAsync(CategoryDto obj);
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(int id);
        Task<CategoryDto> UpdateAsync(CategoryDto obj);
        Task<CategoryDto> DeleteByIdAsync(int id);

    }
}
