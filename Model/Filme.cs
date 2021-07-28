using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeCode.API.Model
{
    

    public class Filme
    {
        [Key()]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }

        
       
    }

}

   

