using Microsoft.AspNetCore.Mvc;
using News.Application.Services;
using News.Dtos;

namespace News.Presentation.Controllers
{
    public class AdminController : Controller
    {
        private readonly INewsServices _NewsServices;

        public AdminController(INewsServices newsServices) 
        {
            _NewsServices = newsServices;
        }
        public async Task<IActionResult> Index()
        {
            var AllNews =( await _NewsServices.GetAllAsync()).Entities;
            return View(AllNews);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewsDto newsDto)
        {
            try
            {
                string filename = "";
                if (newsDto.NewsImage != null)
                {
                    string Newsimages = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "NewsImages");
                    filename = newsDto.NewsImage.FileName;
                    string fullpath = Path.Combine(Newsimages, filename);
                    newsDto.NewsImage.CopyTo(new FileStream(fullpath, FileMode.Create));
                    newsDto.NewsImageString = filename;
                }
                var newNews = await _NewsServices.CreateAsync(newsDto);
                if(newNews.Entity != null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = newNews.Message;
                    return View(newsDto);
                }
            }
            catch
            {
                return View(newsDto);
            }
        }
        public async Task<IActionResult> Update(int id)
        {
            var news = await _NewsServices.GetOneAsync(id);
            return View(news.Entity);
        }
        [HttpPost]
        public async Task<IActionResult> Update(NewsDto newsDto)
        {
            try
            {
                string filename = "";
                if (newsDto.NewsImage != null)
                {
                    string Newsimages = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "NewsImages");
                    filename = newsDto.NewsImage.FileName;
                    string fullpath = Path.Combine(Newsimages, filename);
                    newsDto.NewsImage.CopyTo(new FileStream(fullpath, FileMode.Create));
                    newsDto.NewsImageString = filename;
                    // }
                }
                var newsUpdated = await _NewsServices.UpdateAsync(newsDto);
                if (newsUpdated.Entity == null)
                {
                    ViewBag.Error = newsUpdated.Message;
                    return View(newsDto);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View(newsDto);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var NewsDeleted = await _NewsServices.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
