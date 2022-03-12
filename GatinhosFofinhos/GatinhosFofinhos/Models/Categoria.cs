using System.ComponentModel.DataAnnotations;

namespace GatinhosFofinhos.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdCategoria { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Nome { get; set; } 
        
        [MaxLength(140)]
        public string Descricao { get; set; }

        public string UrlDaCapa { get; set; }
    }
}
