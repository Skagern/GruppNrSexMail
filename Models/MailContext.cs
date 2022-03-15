using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GruppNrSexMail.Models;

namespace GruppNrSexMail.Models
{
    public class MailContext : DbContext
    {
        public DbSet<MailListModel> Mails { get; set; }

        public MailContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<GruppNrSexMail.Models.EmailModel> EmailModel { get; set; }
    }
}
