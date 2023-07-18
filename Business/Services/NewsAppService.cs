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
    public class NewsAppService : INewsAppService
    {
        private readonly IAsyncRepository<News> _rep;
        private readonly IMapper mapper;

        public NewsAppService(IAsyncRepository<News> rep, IMapper mapper)
        {
            this._rep = rep;
            this.mapper = mapper;
        }
        public async Task<NewsDto> AddAsync(NewsDto obj)
        {
            obj.Date = DateTime.Now;
            var entity = mapper.Map<News>(obj);
            var data = await _rep.AddAsync(entity);
            return mapper.Map<NewsDto>(data);
        }
        public async Task<IEnumerable<NewsDto>> GetAllAsync()
        {
            var data = await _rep.GetAllAsync();
            return mapper.Map<IEnumerable<NewsDto>>(data);
        }
        public async Task<NewsDto> GetByIdAsync(int id)
        {
            var data = await _rep.GetByIdAsync(id);
            return mapper.Map<NewsDto>(data);
        }
        public async Task<NewsDto> UpdateAsync(NewsDto obj)
        {
            var entity = mapper.Map<News>(obj);
            var data = await _rep.UpdateAsync(entity);
            return mapper.Map<NewsDto>(data);
        }
        public async Task<NewsDto> DeleteAsync(NewsDto obj)
        {
            var entity = mapper.Map<News>(obj);
            var data = await _rep.DeleteAsync(entity);
            return mapper.Map<NewsDto>(data);
        }
        public async Task<NewsDto> DeleteByIdAsync(int id)
        {
            var data = await _rep.DeleteAsync(id);
            return mapper.Map<NewsDto>(data);
        }

        public IEnumerable<NewsDto> GetAllByCategoryIdAsync(int Id)
        {
            var data = _rep.GetAllByCategoryIdAsync(Id);
            return mapper.Map<IEnumerable<NewsDto>>(data);

        }
    }
}
