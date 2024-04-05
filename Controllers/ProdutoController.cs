using Microsoft.AspNetCore.Mvc;
using Productify_back.Models;
using Productify_back.Repositories;
using Productify_back.DTO;

namespace Productify_back.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoRepository _produtoRepository;
        public ProdutoController(ProdutoRepository produtoRepository) {
            _produtoRepository = produtoRepository;
        }

        [HttpGet(Name = "ListProdutos")]
        public async Task<IActionResult> ListProdutos([FromQuery] ProdutoDTO filtro, [FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        {
            try
            {
                var produtos = await _produtoRepository.ListProdutos(page, pageSize, filtro);

                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListProdutoById([FromRoute] int id)
        {
            try
            {
                var produto = await _produtoRepository.ListProdutoById(id);

                if(produto != null)
                {
                    return Ok(produto); 
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarProduto([FromBody] Produto produto)
        {
            try
            {
                var idProduto = await _produtoRepository.AdicionarProduto(produto);
                return CreatedAtRoute("ListProdutos", new { id = idProduto }, produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarProduto([FromRoute] int id, [FromBody] Produto produto)
        {
            try
            {
                if (id != produto.Id)
                {
                    return BadRequest();
                }

                await _produtoRepository.AtualizarProduto(produto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarProduto([FromRoute] int id)
        {
            try
            {
                await _produtoRepository.DeletarProduto(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
