using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ArteNaPraia.Models
{
    public class Artista
    {
        [Key]
        public int IdArtista {get; set; }
        public string Nome {get; set; }

        public string ChavePix {get; set; }

        public virtual ICollection<Arte> Artes {get; set; }
    }
}