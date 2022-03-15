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
    public class MailListController : ControllerBase
    {
        private readonly MailContext _context;

        public MailListController(MailContext context)
        {
            _context = context;
        }

        // GET: api/MailList
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MailListModel>>> GetMails()
        {
            return await _context.Mails.ToListAsync();
        }

        // GET: api/MailList/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MailListModel>> GetMailListModel(int id)
        {
            var mailListModel = await _context.Mails.FindAsync(id);

            if (mailListModel == null)
            {
                return NotFound();
            }

            return mailListModel;
        }

        // PUT: api/MailList/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMailListModel(int id, MailListModel mailListModel)
        {
            if (id != mailListModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(mailListModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MailListModelExists(id))
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

        // POST: api/MailList
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MailListModel>> PostMailListModel(MailListModel mailListModel)
        {
            _context.Mails.Add(mailListModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMailListModel", new { id = mailListModel.Id }, mailListModel);
        }

        // DELETE: api/MailList/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMailListModel(int id)
        {
            var mailListModel = await _context.Mails.FindAsync(id);
            if (mailListModel == null)
            {
                return NotFound();
            }

            _context.Mails.Remove(mailListModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MailListModelExists(int id)
        {
            return _context.Mails.Any(e => e.Id == id);
        }
    }
}
