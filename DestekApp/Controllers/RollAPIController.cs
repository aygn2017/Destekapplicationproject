using DestekApp.Data;
using DestekApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DestekApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RollAPIController : ControllerBase
    {

        private readonly DestekAppDBContext _context;

        public RollAPIController(DestekAppDBContext context)
        {
            _context = context;
        }

        // GET: api/RolAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol>>> GetRoller()
        {
            return await _context.Roller.ToListAsync();
        }

        // GET: api/RolAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rol>> GetRol(int id)
        {
            var rol = await _context.Roller.FindAsync(id);

            if (rol == null)
            {
                return NotFound();
            }

            return rol;
        }
        [HttpPost]
        public async Task<ActionResult<Rol>> PostRol(Rol rol)
        {
            _context.Roller.Add(rol);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetRol", new { id = rol.RolID }, rol);
        }



        // PUT: api/RolAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRol(int id, Rol rol)
        {
            if (id != rol.RolID)
            {
                return BadRequest();
            }
            _context.Entry(rol).State = EntityState.Modified;
            await _context.SaveChangesAsync();   
            return NoContent();
        }

        // DELETE: api/RolAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            var rol = await _context.Roller.FindAsync(id);
            if (rol == null)
            {
                return NotFound();
            }

            _context.Roller.Remove(rol);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
