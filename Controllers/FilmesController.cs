using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeCode.API.Data;
using WeCode.API.Model;

namespace WeCode.API.Controllers
{
    [Route("filmes")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly Database_Context _context;

        public FilmesController(Database_Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Lista todos os filmes.
        /// </summary>
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<Filme>>> GetFilmes()
        {
            return await _context.Filmes.ToListAsync();
        }

        /// <summary>
        /// Localiza um filme pelo id.
        /// </summary>
        [HttpGet("{id}")]
       
        public async Task<ActionResult<Filme>> GetFilme(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);

            if (filme == null)
            {
                return NotFound();
            }

            return filme;
        }

        /// <summary>
        /// Atualiza o filme pelo id.
        /// </summary>
        [HttpPut("{id}")]
        
        public async Task<IActionResult> PutFilme(int id, Filme filme)
        {
            if (id != filme.Id)
            {
                return BadRequest();
            }

            _context.Entry(filme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmeExists(id))
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
        /// Inclui novo filme.
        /// </summary>
        [HttpPost]
       
        public async Task<ActionResult<Filme>> PostFilme(Filme filme)
        {
            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilme", new { id = filme.Id }, filme);
        }

        /// <summary>
        /// Apaga o filme pelo id.
        /// </summary>
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> DeleteFilme(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);
            if (filme == null)
            {
                return NotFound();
            }

            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmeExists(int id)
        {
            return _context.Filmes.Any(e => e.Id == id);
        }
    }
}
