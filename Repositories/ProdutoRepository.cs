using Microsoft.EntityFrameworkCore;
using Productify_back.Context;
using Productify_back.Models;
using Productify_back.DTO;

namespace Productify_back.Repositories
{
    public class ProdutoRepository
    {
        private readonly ModelContext _context;

        public ProdutoRepository(ModelContext context)
        {
            _context = context;
        }

        public async Task<ListaPaginadaDTO> ListProdutos(int page, int pageSize, string filtro)
        {
            try
            {
                var query = _context.Produtos.AsQueryable();

                if (!string.IsNullOrEmpty(filtro))
                {
                    filtro = filtro.ToLower();

                    query = query.Where(p => p.Nome.ToLower().Contains(filtro) || p.Descricao.ToLower().Contains(filtro));
                }

                var total = await query.CountAsync();

                query = query.Skip((page - 1) * pageSize)
                    .Take(pageSize);

                var produtos = await query.ToListAsync();

                return new ListaPaginadaDTO(produtos, page, total, pageSize); ;
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<Produto> ListProdutoById(int id)
        {
            try 
            {
                return await _context.Produtos.FindAsync(id);
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<int> AdicionarProduto(Produto produto)
        {
            try 
            {
                produto.SetDataDeCriacao();

                _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();
                return produto.Id;
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                throw;
            }
    }

        public async Task AtualizarProduto(Produto produto)
        {
            try
            {
                produto.SetDataDeCriacao();
                _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            } catch (Exception ex) {
                    Console.WriteLine(ex.ToString());
                    throw;
            }
        }

        public async Task DeletarProduto(int id)
        {
            try
            {
                var produto = await _context.Produtos.FindAsync(id);
                if (produto != null)
                {
                    _context.Produtos.Remove(produto);
                    await _context.SaveChangesAsync();
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
