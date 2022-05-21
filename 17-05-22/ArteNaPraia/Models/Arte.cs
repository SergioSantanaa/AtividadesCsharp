using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArteNaPraia.Models{
    public class Arte{

        [Key]
        public int IdArte { get; set; }
        public string Nome { get; set; }
        [Required(ErrorMessage = "Nome da arte obrigátorio")]
        public double Preco { get; set; }
        [Required(ErrorMessage ="Preço da Arte é obrigátorio(Caso seja amostra coloque 0)")]
        public bool EmExposicao { get; set; }
        public string Descricao { get; set; }
        [ForeignKey("Artista")]

        public int IdArtista { get; set; }

        public virtual Artista Artista {get;set;}

    }


}