using System.ComponentModel.DataAnnotations;

namespace Productify_back.DTO
{
    public class ProdutoDTO
    {
        public int? ID { get; set; }

        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public decimal? Preco { get; set; }

        public DateTime? DataDeCriacao { get; set; }

        public ProdutoDTO() {}
    }
}
