using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GruppNrSexMail.Models;

namespace GruppNrSexMail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly MailContext _context;

        public EmailController(MailContext context)
        {
            _context = context;
        }


        // POST: api/Email
        // SEND A SPECIFIK EMAIL
        [HttpPost]
        public async Task<bool> SendMail(EmailModel emailmodel)
        {
            try
            {
                Example emailexample = new();
                var response = await Example.Execute(emailmodel.To, emailmodel.Subject, emailmodel.Body
                    , emailmodel.Body);
                if (response != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                Console.WriteLine("Something went wrong. Bad connection!");
                return false;
            }
        }

        // GET: api/Email
        // RETURNS A LIST OVER SENT EMAILS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmailModel>>> GetEmailModels()
        {
            return await _context.EmailModel.ToListAsync();
        }

        // GET: api/Email/5
        // RETURNS A SPECIFIK EMAIL
        [HttpGet("{id}")]
        public async Task<ActionResult<EmailModel>> GetEmailModel(int id)
        {
            var emailModel = await _context.EmailModel.FindAsync(id);

            if (emailModel == null)
            {
                return NotFound();
            }

            return emailModel;
        }
    }
}
