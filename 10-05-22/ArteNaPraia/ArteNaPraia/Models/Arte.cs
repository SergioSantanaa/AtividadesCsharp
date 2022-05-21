
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArteNaPraia.Models

{
    public class Arte
    {
        [Key]


        public int IdArte {get; set;}
        [Required(ErrorMessage = "O nome arte E obrigátorio" )]

        public string Nome {get; set;}

        [Required(ErrorMessage = "O nome é obrigatorio")]

        public string Descricao { get; set; }

        [ForeignKey("Artista")]


        public int IdArtista {get; set;}

        public virtual Artista Artista {get; set;}







    }
}