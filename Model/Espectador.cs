using System.ComponentModel.DataAnnotations;

namespace WeCode.API.Model
{
    public class Espectador
    {
        [Key()]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        

        
        
    }

}
