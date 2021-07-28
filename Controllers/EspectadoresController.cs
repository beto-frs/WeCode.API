using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeCode.API.Data;
using WeCode.API.Model;

namespace WeCode.API.Controllers
{
    [Route("espectadores")]
    [ApiController]
    public class EspectadoresController : ControllerBase
    {
        private readonly Database_Context _context;

        public EspectadoresController(Database_Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Lista todos os espectadores.
        /// </summary>
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<Espectador>>> GetEspectadores()
        {
            return await _context.Espectadores.ToListAsync();
        }

        /// <summary>
        /// Localiza um espectador pelo id.
        /// </summary>
        [HttpGet("{id}")]
        
        public async Task<ActionResult<Espectador>> GetEspectador(int id)
        {
            var espectador = await _context.Espectadores.FindAsync(id);

            if (espectador == null)
            {
                return NotFound();
            }

            return espectador;
        }

        /// <summary>
        /// Altera um espectador pelo id.
        /// </summary>
        [HttpPut("{id}")]
        
        public async Task<IActionResult> PutEspectador(int id, Espectador espectador)
        {
            if (id != espectador.Id)
            {
                return BadRequest();
            }

            _context.Entry(espectador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspectadorExists(id))
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

        /// <summary>
        /// Inclui um espectador.
        /// </summary>
        [HttpPost]
        
        public async Task<ActionResult<Espectador>> PostEspectador(Espectador espectador)
        {
            _context.Espectadores.Add(espectador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEspectador", new { id = espectador.Id }, espectador);
        }

        /// <summary>
        /// Apaga um espectador pelo id.
        /// </summary>
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> DeleteEspectador(int id)
        {
            var espectador = await _context.Espectadores.FindAsync(id);
            if (espectador == null)
            {
                return NotFound();
            }

            _context.Espectadores.Remove(espectador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EspectadorExists(int id)
        {
            return _context.Espectadores.Any(e => e.Id == id);
        }
    }
}
