using Jumia.Dtos.ResultView;
using News.Dtos;
using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.Services
{
    public interface INewsServices
    {
        Task<ResultView<NewsDto>> CreateAsync(NewsDto newsDto);
        Task<ResultView<NewsDto>> UpdateAsync(NewsDto newsDto);
        Task<ResultView<NewsDto>> DeleteAsync(int Newsid);
        Task<ResultDataList<NewsDto>> GetAllAsync();
        Task<ResultView<NewsDto>> GetOneAsync(int id);
    }
}
