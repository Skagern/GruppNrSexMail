using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GruppNrSexMail.Models
{
    public class SendMailModel
    {
        public int Id { get; set; }
        public string Recipients { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }

}
