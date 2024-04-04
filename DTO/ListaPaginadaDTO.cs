using Productify_back.Models;

namespace Productify_back.DTO
{
    public class ListaPaginadaDTO
    {
        public List<Produto> Items { get; set; }
        public int page { get; set; }   
        public int total { get; set; } 
        public int totalPages { get; set; }

        public ListaPaginadaDTO(List<Produto> Items, int page, int total, int totalPages) {
            this.Items = Items;
            this.page = page;  
            this.total = total;
            this.totalPages = totalPages;
        }
    }
}
