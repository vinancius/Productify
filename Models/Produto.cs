using System.ComponentModel.DataAnnotations;

namespace Productify.Models
{
    public class Produto
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(45)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(150)]
        public string? Descricao { get; set; }

        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999999999999999.99)]
        public decimal? Preco { get; set; }

        public DateTime? DataDeCriacao { get; set; }

        public Produto()
        {
            DataDeCriacao = DateTime.Now;
        }
    }
}
