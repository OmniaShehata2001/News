using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Models
{
    public class news
    {
        public int Id { get; set; }
        [Required]
        public string NewsTitle { get; set; }
        [Required]
        public DateTime NewsDate { get; set; }
        [Required]
        public string NewsImage {  get; set; }
        [Required]
        [MaxLength(200)]
        public string NewsDetails {  get; set; }
        public bool IsDeleted { get; set; }

    }
}
