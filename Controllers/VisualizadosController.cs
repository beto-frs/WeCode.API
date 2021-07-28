using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeCode.API.Data;
using WeCode.API.ViewModel;

namespace WeCode.API.Controllers
{
    [Route("visualizados")]
    [ApiController]
    public class VisualizadosController : ControllerBase
    {
        private readonly Database_Context _context;

        public VisualizadosController(Database_Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Lista todos as visualizações.
        /// </summary>
        
        [HttpGet]
       
        public async Task<ActionResult<IEnumerable<Visualizado>>> GetVisualizados()
        {
            return await _context.Visualizados.Include(x => x.Espectador)
                .Include(x => x.Filme)
                .ToListAsync();
        }

        /// <summary>
        /// Localiza uma visualização pelo Id.
        /// </summary>
        [HttpGet("{id}")]
        
        public async Task<ActionResult<Visualizado>> GetVisualizado(int id)
        {
            var visualizado = await _context.Visualizados.FindAsync(id);
            _context.Visualizados.Include(x => x.Espectador)
            .Include(x => x.Filme)
            .ToList();
                

            if (visualizado == null)
            {
                return NotFound();
            }

            return visualizado;
        }

        /// <summary>
        /// Atualiza a visualização pelo id.
        /// </summary>
        [HttpPut("{id}")]
        
        public async Task<IActionResult> PutVisualizado(int id, Visualizado visualizado)
        {
            if (id != visualizado.id)
            {
                return BadRequest();
            }

            _context.Entry(visualizado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisualizadoExists(id))
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
        /// Inclui nova visualização.
        /// </summary>
        [HttpPost]
        
        public async Task<ActionResult<Visualizado>> PostVisualizado(Visualizado visualizado)
        {
            _context.Visualizados.Add(visualizado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVisualizado", new { id = visualizado.id }, visualizado);
        }

        /// <summary>
        /// Apaga o filme pelo id.
        /// </summary>
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> DeleteVisualizado(int id)
        {
            var visualizado = await _context.Visualizados.FindAsync(id);
            if (visualizado == null)
            {
                return NotFound();
            }

            _context.Visualizados.Remove(visualizado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VisualizadoExists(int id)
        {
            return _context.Visualizados.Any(e => e.id == id);
        }

        /// <summary>
        /// Lista a quantidade de espectadores por filme pelo Id do Filme.
        /// </summary>
        
        [HttpGet]
        [Route("filme")]
        public async Task<ActionResult<IEnumerable<Visualizado>>> FilmeVisualizado(int id)
        {
            var visualizado = _context.Visualizados.Where(x => x.FilmeId == id)
            .Include(x => x.Espectador)
            .Include(x => x.Filme)
            .ToList();

            return visualizado;
        }

        /// <summary>
        /// Lista a quantidade de filmes por espectador pelo Id do Espectador.
        /// </summary>
        
        [HttpGet]
        [Route("espectadores")]
        public async Task<ActionResult<IEnumerable<Visualizado>>> EspectadorVisualizado(int id)
        {
            var visualizado = _context.Visualizados.Where(x => x.EspectadorId == id)
            .Include(x => x.Espectador)
            .Include(x => x.Filme)
            .ToList();

            return visualizado;
        }


    }
}

