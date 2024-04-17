using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Dtos
{
    public class NewsDto
    {
        public int Id { get; set; }
        [Required]
        public string NewsTitle { get; set; }
        [Required]
        public DateTime NewsDate { get; set; }
        [Required]
        public string NewsImageString { get; set; }
        public IFormFile NewsImage { get; set; }
        [Required]
        [MaxLength(200)]
        public string NewsDetails { get; set; }
        public bool IsDeleted { get; set; }
    }
}
