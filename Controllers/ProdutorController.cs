using Microsoft.AspNetCore.Mvc;
using Productify.Models;
using Productify.Repositories;

namespace Productify.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutorController : SuperController
    {
        public ProdutorController(ProdutoRepository _produtoRepository) : base(_produtoRepository) { }

        [HttpGet]
        public async Task<IActionResult> ListProdutos(int page = 1, int pageSize = 5)
        {
            var produtos = await _produtoRepository.ListProdutos(page, pageSize);

            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListProdutoById(int id)
        {
            var produto = await _produtoRepository.ListProdutoById(id);

            if(produto != null)
            {
                return Ok(produto); 
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarProduto(int id, [FromBody] Produto produto)
        {
            if (id != produto.ID)
            {
                return BadRequest();
            }

            await _produtoRepository.AtualizarProduto(produto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> DeletarProduto(int id)
        {
            await _produtoRepository.DeletarProduto(id);
            return NoContent();
        }
    }
}
