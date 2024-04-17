using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.Contract
{
    public interface INewsRepository
    {
        Task<news> CreateNews(news News);
        Task<news> UpdateNews(news News);
        Task<news> DeleteNews(news News);
        Task<IQueryable<news>> GetAllNews();
        Task<news> GetNewsById(int id);
        Task<int> Save();
    }
}
