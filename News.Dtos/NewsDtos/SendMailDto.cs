using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Dtos.NewsDtos
{
    public class SendMailDto
    {
        public string YourName {  get; set; }
        public string YourEmail { get; set; }
        public string FriendEmail { get; set; }
        public string Message { get; set; }
        public string NewsTitle { get; set; }
    }
}
