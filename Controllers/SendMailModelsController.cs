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
    public class SendMailModelsController : ControllerBase
    {
        private readonly MailContext _context;

        public SendMailModelsController(MailContext context)
        {
            _context = context;
        }

        // GET: api/SendMailModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SendMailModel>>> GetSendMails()
        {
            return await _context.SendMails.ToListAsync();
        }

        // GET: api/SendMailModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SendMailModel>> GetSendMailModel(int id)
        {
            var sendMailModel = await _context.SendMails.FindAsync(id);

            if (sendMailModel == null)
            {
                return NotFound();
            }

            return sendMailModel;
        }

        // PUT: api/SendMailModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSendMailModel(int id, SendMailModel sendMailModel)
        {
            if (id != sendMailModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(sendMailModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SendMailModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SendMailModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SendMailModel>> PostSendMailModel(SendMailModel sendMailModel)
        {
            _context.SendMails.Add(sendMailModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSendMailModel", new { id = sendMailModel.Id }, sendMailModel);
        }

        // DELETE: api/SendMailModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSendMailModel(int id)
        {
            var sendMailModel = await _context.SendMails.FindAsync(id);
            if (sendMailModel == null)
            {
                return NotFound();
            }

            _context.SendMails.Remove(sendMailModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SendMailModelExists(int id)
        {
            return _context.SendMails.Any(e => e.Id == id);
        }
    }
}
