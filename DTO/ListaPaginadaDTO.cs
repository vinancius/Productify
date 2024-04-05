using Productify_back.Models;

namespace Productify_back.DTO
{
    public class ListaPaginadaDTO
    {
        public List<Produto> Itens { get; set; }
        public int Page { get; set; }   
        public int Total { get; set; } 
        public int TotalPages { get; set; }

        public ListaPaginadaDTO(List<Produto> itens, int page, int total, int totalPages) {
            this.Itens = itens;
            this.Page = page;  
            this.Total = total;
            this.TotalPages = totalPages;
        }
    }
}
