using Microsoft.AspNetCore.Mvc;
using News.Application.Services;
using News.Dtos.NewsDtos;
using System.Net.Mail;

namespace News.Presentation.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsServices _NewsServices;

        public NewsController(INewsServices NewsServices) 
        {
            _NewsServices = NewsServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> News(DateTime? filterDate)
        {
            
            var AllNews = await _NewsServices.GetAllAsync();

            var distinctDates = AllNews.Entities
               .Select(news => new { news.NewsDate.Year, news.NewsDate.Month })
               .Distinct()
               .OrderByDescending(date => date.Year)
               .ThenByDescending(date => date.Month)
               .ToList();
            ViewBag.DistinctDates = distinctDates;

            if (filterDate.HasValue)
            {
                AllNews.Entities = AllNews.Entities
           .Where(news => news.NewsDate.Month == filterDate.Value.Month && news.NewsDate.Year == filterDate.Value.Year)
           .ToList();
            }
            return View(AllNews.Entities);
        }
        [HttpPost]
        public IActionResult News([FromBody] SendMailDto sendMailDto)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(sendMailDto.YourEmail, sendMailDto.YourName);
            message.To.Add(new MailAddress(sendMailDto.FriendEmail));
            message.Subject = sendMailDto.Message;
            message.Body = sendMailDto.NewsTitle;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("omniashehata354@gmail.com", "toqb wshi pthw scrf");
            smtp.Send(message);
            return Json(new { success = true });
        }
    }
}
