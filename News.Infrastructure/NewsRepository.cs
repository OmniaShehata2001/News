using News.Application.Contract;
using News.Context;
using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Infrastructure
{
    public class NewsRepository : INewsRepository
    {
        private readonly NewsContext _NewsContext;

        public NewsRepository(NewsContext newsContext) 
        {
            _NewsContext = newsContext;
        }
        public async Task<news> CreateNews(news News)
        {
            return (await _NewsContext.News.AddAsync(News)).Entity;
        }

        public Task<news> DeleteNews(news News)
        {
            return Task.FromResult(_NewsContext.News.Remove(News).Entity);
        }

        public Task<IQueryable<news>> GetAllNews()
        {
            return Task.FromResult(_NewsContext.News.Select(p => p));
        }

        public async Task<news> GetNewsById(int id)
        {
            return await _NewsContext.News.FindAsync(id);
        }

        public async Task<int> Save()
        {
            return await _NewsContext.SaveChangesAsync();
        }

        public Task<news> UpdateNews(news News)
        {
            return Task.FromResult(_NewsContext.News.Update(News).Entity);
        }
    }
}
