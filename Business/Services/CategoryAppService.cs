using AutoMapper;
using Business.Dto;
using Domain.Entities;
using Business.Contracts.Feature;
using Business.Contracts.Persistence.IRepository;
using Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalApp.Demo.Application.Services
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly IAsyncRepository<Category> _rep;
        private readonly IMapper mapper;

        public CategoryAppService(IAsyncRepository<Category> rep, IMapper mapper)
        {
            this._rep = rep;
            this.mapper = mapper;
        }
        public async Task<CategoryDto> AddAsync(CategoryDto obj)
        {
            var entity = mapper.Map<Category>(obj);
            var data = await _rep.AddAsync(entity);
            return mapper.Map<CategoryDto>(data);
        }
        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var data = await _rep.GetAllAsync();
            return mapper.Map<IEnumerable<CategoryDto>>(data);
        }
        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var data = await _rep.GetByIdAsync(id);
            return mapper.Map<CategoryDto>(data);
        }
        public async Task<CategoryDto> UpdateAsync(CategoryDto obj)
        {
            var entity = mapper.Map<Category>(obj);
            var data = await _rep.UpdateAsync(entity);
            return mapper.Map<CategoryDto>(data);
        }
        public async Task<CategoryDto> DeleteAsync(CategoryDto obj)
        {
            var entity = mapper.Map<Category>(obj);
            var data = await _rep.DeleteAsync(entity);
            return mapper.Map<CategoryDto>(data);
        }
        public async Task<CategoryDto> DeleteByIdAsync(int id)
        {
            var data = await _rep.DeleteAsync(id);
            return mapper.Map<CategoryDto>(data);
        }
    }
}
