using AutoMapper;
using Jumia.Dtos.ResultView;
using News.Application.Contract;
using News.Dtos;
using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.Services
{
    public class NewsServices : INewsServices
    {
        private readonly INewsRepository _NewsRepository;
        private readonly IMapper _Mapper;

        public NewsServices(INewsRepository NewsRepository, IMapper mapper)
        {
            _NewsRepository = NewsRepository;
            _Mapper = mapper;
        }
        public async Task<ResultView<NewsDto>> CreateAsync(NewsDto newsDto)
        {
            var Newsexist = await _NewsRepository.GetNewsById(newsDto.Id);
            if (Newsexist != null)
            {
                return new ResultView<NewsDto>
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = "News already exist"
                };
            }
            else
            {
                var NewsModel = _Mapper.Map<news>(newsDto);
                var NewNews = await _NewsRepository.CreateNews(NewsModel);
                await _NewsRepository.Save();
                var NewNewsDto = _Mapper.Map<NewsDto>(NewNews);
                return new ResultView<NewsDto>
                {
                    Entity = NewNewsDto,
                    IsSuccess = true,
                    Message = "News created successfully"
                };
            }
        }

        public async Task<ResultView<NewsDto>> DeleteAsync(int Newsid)
        {
            var News = await _NewsRepository.GetNewsById(Newsid);
            News.IsDeleted = true;
            await _NewsRepository.Save();
            var NewsDeletedDto = _Mapper.Map<NewsDto>(News);
            return new ResultView<NewsDto>
            {
                Entity = NewsDeletedDto,
                IsSuccess = true,
                Message = "News Deleted Successfully"
            };
        }

        public async Task<ResultDataList<NewsDto>> GetAllAsync()
        {
            var AllNews = (await _NewsRepository.GetAllNews()).Where(p => p.IsDeleted == false).ToList();
            var AllNewsDto = _Mapper.Map<List<NewsDto>>(AllNews);
            return new ResultDataList<NewsDto>
            {
                Entities = AllNewsDto,
                Count = AllNews.Count
            };
        }

        public async Task<ResultView<NewsDto>> GetOneAsync(int id)
        {
            var News = await _NewsRepository.GetNewsById(id);
            if(News == null)
            {
                return new ResultView<NewsDto>
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = "News not found"
                };
            }
            else
            {
                var NewsDto = _Mapper.Map<NewsDto>(News);
                return new ResultView<NewsDto>
                {
                    Entity = NewsDto,
                    IsSuccess = true,
                    Message = "News exist"
                };
            }
        }

        public async Task<ResultView<NewsDto>> UpdateAsync(NewsDto newsDto)
        {
            var NewsModel = _Mapper.Map<news>(newsDto);
            var NewsUpdates = await _NewsRepository.UpdateNews(NewsModel);
            await _NewsRepository.Save();
            var NewsUpdatedDto = _Mapper.Map<NewsDto>(NewsUpdates);
            return new ResultView<NewsDto>
            {
                Entity = NewsUpdatedDto,
                IsSuccess = true,
                Message = "News updated successfully"
            };
            
        }
    }
}
