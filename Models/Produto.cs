using System.ComponentModel.DataAnnotations;

namespace Productify.Models
{
    public class Produto
    {
        [Key]
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public DateTime DataDeCriacao { get; set; }

        public Produto()
        {
            DataDeCriacao = DateTime.Now;
        }
    }
}
