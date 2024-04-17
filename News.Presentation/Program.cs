using Microsoft.EntityFrameworkCore;
using News.Application.Contract;
using News.Application.Services;
using News.Context;
using News.Infrastructure;

namespace News.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<NewsContext>(op =>
            {
                op.UseSqlServer(builder.Configuration.GetConnectionString("Db"));
            });
            builder.Services.AddScoped<INewsServices, NewsServices>();
            builder.Services.AddScoped<INewsRepository, NewsRepository>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=News}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
