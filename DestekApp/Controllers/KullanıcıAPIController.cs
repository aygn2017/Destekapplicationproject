using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DestekApp.Data;
using DestekApp.Models;

namespace DestekApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullanıcıAPIController : ControllerBase
    {
        private readonly DestekAppDBContext _context;

        public KullanıcıAPIController(DestekAppDBContext context)
        {
            _context = context;
        }

        // GET: api/KullanıcıAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kullanıcı>>> GetKullanıcılar()
        {
            return await _context.Kullanıcılar.ToListAsync();
        }


        



        // GET: api/KullanıcıAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kullanıcı>> GetKullanıcı(int id)
        {
            var kullanıcı = await _context.Kullanıcılar.FindAsync(id);

            if (kullanıcı == null)
            {
                return NotFound();
            }

            return kullanıcı;
        }

        // GET: api/KullanıcıAPI/GetKullanıcılarBYRol/4
        [HttpGet("GetKullanıcılarBYRol/{rid}")]
        public async Task<ActionResult<IEnumerable<Kullanıcı>>> GetKullanıcılarBYRol(int rid)
        {
            return await _context.Kullanıcılar.Where(a => a.RolID == rid).ToListAsync();
        }

        // PUT: api/KullanıcıAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKullanıcı(int id, Kullanıcı kullanıcı)
        {
            if (id != kullanıcı.KullanıcıID)
            {
                return BadRequest();
            }

            _context.Entry(kullanıcı).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KullanıcıExists(id))
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

        // POST: api/KullanıcıAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kullanıcı>> PostKullanıcı(Kullanıcı kullanıcı)
        {
            _context.Kullanıcılar.Add(kullanıcı);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKullanıcı", new { id = kullanıcı.KullanıcıID }, kullanıcı);
        }

        // DELETE: api/KullanıcıAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKullanıcı(int id)
        {
            var kullanıcı = await _context.Kullanıcılar.FindAsync(id);
            if (kullanıcı == null)
            {
                return NotFound();
            }

            _context.Kullanıcılar.Remove(kullanıcı);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KullanıcıExists(int id)
        {
            return _context.Kullanıcılar.Any(e => e.KullanıcıID == id);
        }
    }
}
