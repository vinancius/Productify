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

        public async Task<ListaPaginadaDTO> ListProdutos(int page, int pageSize, ProdutoDTO filtro)
        {
            try
            {
                var query = _context.Produtos.AsQueryable();

                query = query.Skip((page - 1) * pageSize)
                    .Take(pageSize);

                if (!string.IsNullOrEmpty(filtro.Nome))
                {
                    query = query.Where(p => p.Nome.Equals(filtro.Nome));
                }

                if (!string.IsNullOrEmpty(filtro.Descricao))
                {
                    query = query.Where(p => p.Descricao.Equals(filtro.Descricao));
                }

                var produtos = await query.ToListAsync();
                var total = await query.CountAsync();

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
