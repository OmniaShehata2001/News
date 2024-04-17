using Microsoft.EntityFrameworkCore;
using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Context
{
    public class NewsContext : DbContext
    {
        public DbSet<news> News { get; set; }
        public NewsContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
    }
}
