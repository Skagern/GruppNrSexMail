using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GruppNrSexMail.Models
{
    public class MailContext : DbContext
    {
        public DbSet<MailListModel> Mails { get; set; }
        public DbSet<SendMailModel> SendMails { get; set; }

        public MailContext(DbContextOptions options) : base(options)
        {

        }
    }
}
