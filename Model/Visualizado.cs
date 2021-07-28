using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WeCode.API.Model;

namespace WeCode.API.ViewModel
{
    public class Visualizado
    {
        [Key()]
        public int id { get; set; }

        [ForeignKey("Espectador")]
        public int EspectadorId { get; set; }
        public virtual Espectador Espectador { get; set; }
        
        

        [ForeignKey("Filme")]
        public int FilmeId { get; set; }
        public virtual Filme Filme { get; set; }

        

        

        

       

    }
}
